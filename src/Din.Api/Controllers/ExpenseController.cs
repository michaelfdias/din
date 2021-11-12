using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;
using Din.Domain.Models.Enumerations;
using Din.Domain.Repositories;
using Din.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Din.Api.Controllers
{
    [ApiController]
    [Route("expenses")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpGet("{year:int}/{month}")]
        [ProducesResponseType(typeof(IEnumerable<Expense>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int year, Month month)
        {
            return Ok(await _expenseRepository.Get(new Round(year, month)));
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(Expense), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _expenseRepository.Get(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Expense), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(ExpenseRequest req)
        {
            var currentRound = Round.Current();
            var round = new Round(req.Year ?? currentRound.Year, req.Month ?? currentRound.Month);
            var expense = new Expense(req.Name, round)
            {
                DueDay = req.DueDay,
                Value = req.Value,
                PinnedExpenseId = req.PinnedExpenseId
            };
            var isCreated = await _expenseRepository.Create(expense);
            if (!isCreated) return BadRequest();
            return Created(new Uri($"{Request.Path}/{expense.Id}", UriKind.Relative), expense);
        }
    }
}
