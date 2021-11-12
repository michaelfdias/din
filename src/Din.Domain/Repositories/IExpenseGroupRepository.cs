using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;

namespace Din.Domain.Repositories
{
    public interface IExpenseGroupRepository
    {
        Task<IEnumerable<ExpenseGroup>> Get();
        Task<ExpenseGroup> Get(Guid id);
        Task<bool> Create(ExpenseGroup expense);
    }
}
