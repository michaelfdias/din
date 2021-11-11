using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;
using Din.Domain.Repositories;

namespace Din.Data.Repositories
{
    public class PinnedExpenseRepository : IPinnedExpenseRepository
    {
        private IEnumerable<PinnedExpense> _pinnedExpenses = new List<PinnedExpense>();

        public async Task<IEnumerable<PinnedExpense>> Get()
        {
            return _pinnedExpenses;
        }

        public async Task<PinnedExpense> Get(Guid id)
        {
            return _pinnedExpenses.FirstOrDefault(pe => pe.Id == id);
        }

        public async Task<bool> Create(PinnedExpense pinnedExpense)
        {
            _pinnedExpenses = _pinnedExpenses.Append(pinnedExpense);
            return true;
        }
    }
}
