using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Din.Domain.Models.Entities;
using Din.Domain.Repositories;

namespace Din.Domain.Services
{
    public class ExpenseBookService : IExpenseBookService
    {
        private readonly IPinnedExpenseRepository _pinnedExpenseRepository;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseBookService(
            IPinnedExpenseRepository pinnedExpenseRepository,
            IExpenseRepository expenseRepository)
        {
            _pinnedExpenseRepository = pinnedExpenseRepository;
            _expenseRepository = expenseRepository;
        }

        public async Task<IEnumerable<Expense>> Get(Round round)
        {
            var expensesBook = new List<Expense>();
            var pinnedExpenses = await _pinnedExpenseRepository.Get();
            var expenses = await _expenseRepository.Get(round);
            expenses = expenses.ToList();
            expensesBook.AddRange(expenses);
            expensesBook.AddRange(pinnedExpenses
                .Where(pe => expenses.All(e => e.PinnedExpenseId != pe.Id))
                .Select(pe => new Expense(pe.Name, round)
                {
                    DueDay = pe.DueDay,
                    Value = pe.Value,
                    PinnedExpenseId = pe.Id
                }));
            return expensesBook;
        }
    }
}
