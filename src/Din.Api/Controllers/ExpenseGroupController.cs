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
    [Route("expenses-group")]
    public class ExpenseGroupController : ControllerBase
    {
        private readonly IExpenseGroupRepository _expenseGroupRepository;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseGroupController(
            IExpenseGroupRepository expenseGroupRepository,
            IExpenseRepository expenseRepository)
        {
            _expenseGroupRepository = expenseGroupRepository;
            _expenseRepository = expenseRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExpenseGroup>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get()
        {
            var groups = await _expenseGroupRepository.Get();
            if (!groups.Any()) return NoContent();
            return Ok(groups);
        }
        
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(ExpenseGroup), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var group = await _expenseGroupRepository.Get(id);
            if (group is null) return NotFound();
            return Ok(group);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Expense), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(ExpenseGroupRequest req)
        {
            var currentRound = Round.Current();
            var round = new Round(req.Year ?? currentRound.Year, req.Month ?? currentRound.Month);
            var expense = new Expense(req.Name, round)
            {
                DueDay = req.DueDay,
                Value = req.Value
            };
            var expenseGroup = ExpenseGroup.Build(expense, req.Times);
            await _expenseGroupRepository.Create(expenseGroup);
            await _expenseRepository.CreateMany(expenseGroup.Expenses);
            return Created(new Uri($"{Request.Path}/{expenseGroup.Id}", UriKind.Relative), expenseGroup);
        }
    }
}
