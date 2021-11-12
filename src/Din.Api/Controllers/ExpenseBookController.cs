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
    [Route("expenses-book")]
    public class ExpenseBookController : ControllerBase
    {
        private readonly ExpenseBookService _expenseBookService;

        public ExpenseBookController(ExpenseBookService expenseBookService)
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
