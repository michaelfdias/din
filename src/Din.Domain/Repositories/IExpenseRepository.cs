using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;

namespace Din.Domain.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> Get(Round round);
        Task<Expense> Get(Guid id);
        Task<bool> Create(Expense expense);
        Task<bool> CreateMany(IEnumerable<Expense> expenses);
    }
}
