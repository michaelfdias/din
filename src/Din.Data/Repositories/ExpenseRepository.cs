using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;
using Din.Domain.Repositories;

namespace Din.Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private IEnumerable<Expense> _expenses = new List<Expense>();

        public async Task<IEnumerable<Expense>> Get(Round round)
        {
            return _expenses.Where(e => e.Round.Equals(round));
        }

        public async Task<Expense> Get(Guid id)
        {
            return _expenses.FirstOrDefault(pe => pe.Id == id);
        }

        public async Task<bool> Create(Expense expense)
        {
            _expenses = _expenses.Append(expense);
            return true;
        }
    }
}
