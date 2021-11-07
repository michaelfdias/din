using System.Collections.Generic;

namespace Din.Domain.Models.Entities
{
    public class ExpenseBook
    {
        public IList<PinnedExpense> PinnedExpenses { get; set; } = new List<PinnedExpense>();
        public IList<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
