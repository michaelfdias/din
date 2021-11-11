using System.Collections.Generic;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;

namespace Din.Domain.Services
{
    public interface IExpenseBookService
    {
        Task<IEnumerable<Expense>> Get(Round round);
    }
}
