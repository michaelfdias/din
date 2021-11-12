using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;
using Din.Domain.Repositories;

namespace Din.Data.Repositories
{
    public class ExpenseGroupRepository : IExpenseGroupRepository
    {
        private IEnumerable<ExpenseGroup> _expensesGroup = new List<ExpenseGroup>();

        public async Task<IEnumerable<ExpenseGroup>> Get()
        {
            return _expensesGroup;
        }

        public async Task<ExpenseGroup> Get(Guid id)
        {
            return _expensesGroup.FirstOrDefault(eg => eg.Id == id);
        }

        public async Task<bool> Create(ExpenseGroup expense)
        {
            _expensesGroup = _expensesGroup.Append(expense);
            return true;
        }
    }
}
