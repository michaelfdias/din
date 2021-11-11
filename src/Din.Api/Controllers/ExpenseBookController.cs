using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;
using Din.Domain.Models.Enumerations;
using Din.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Din.Api.Controllers
{
    [ApiController]
    [Route("expense-book")]
    public class ExpenseBookController : ControllerBase
    {
        private readonly IExpenseBookService _expenseBookService;

        public ExpenseBookController(IExpenseBookService expenseBookService)
        {
            _expenseBookService = expenseBookService;
        }

        [HttpGet("{year:int}/{month}")]
        [ProducesResponseType(typeof(IEnumerable<Expense>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int year, Month month)
        {
            return Ok(await _expenseBookService.Get(new Round(year, month)));
        }
    }
}
