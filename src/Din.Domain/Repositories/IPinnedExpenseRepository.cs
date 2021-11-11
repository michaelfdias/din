using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;

namespace Din.Domain.Repositories
{
    public interface IPinnedExpenseRepository
    {
        Task<IEnumerable<PinnedExpense>> Get();
        Task<PinnedExpense> Get(Guid id);
        Task<bool> Create(PinnedExpense pinnedExpense);
    }
}
