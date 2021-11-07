using System.Collections.Generic;
using System.Linq;

namespace Din.Domain.Models.Entities
{
    public class ExpenseBook
    {
        public IList<PinnedExpense> PinnedExpenses { get; set; } = new List<PinnedExpense>();
        public IList<Expense> Expenses { get; set; } = new List<Expense>();

        public IList<Expense> GetRoundExpenses(Round round)
        {
            var roundExpenses = new List<Expense>();
            roundExpenses.AddRange(Expenses.Where(e => e.Round.Equals(round)));
            roundExpenses.AddRange(PinnedExpenses
                .Where(pe => Expenses.All(e => e.PinnedExpenseId != pe.Id))
                .Select(pe => new Expense(pe.Name, round)
                {
                    DueDay = pe.DueDay,
                    Value = pe.Value,
                    PinnedExpenseId = pe.Id
                }));
            return roundExpenses;
        }
    }
}
