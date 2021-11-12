using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;
using Din.Domain.Repositories;
using Din.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Din.Api.Controllers
{
    [ApiController]
    [Route("pinned-expenses")]
    public class PinnedExpenseController : ControllerBase
    {
        private readonly IPinnedExpenseRepository _pinnedExpenseRepository;

        public PinnedExpenseController(IPinnedExpenseRepository pinnedExpenseRepository)
        {
            _pinnedExpenseRepository = pinnedExpenseRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PinnedExpense>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get()
        {
            var expenses = await _pinnedExpenseRepository.Get();
            if (!expenses.Any()) return NoContent();
            return Ok(expenses);
        }
        
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(PinnedExpense), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var pinnedExpense = await _pinnedExpenseRepository.Get(id);
            if (pinnedExpense is null) return NotFound();
            return Ok(pinnedExpense);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PinnedExpense), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(PinnedExpenseRequest req)
        {
            var pinnedExpense = new PinnedExpense(req.Name)
            {
                DueDay = req.DueDay,
                Value = req.Value
            };
            var isCreated = await _pinnedExpenseRepository.Create(pinnedExpense);
            if (!isCreated) return BadRequest();
            return Created(new Uri($"{Request.Path}/{pinnedExpense.Id}", UriKind.Relative), pinnedExpense);
        }
    }
}
