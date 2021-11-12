using System;
using System.Collections.Generic;
using System.Linq;

namespace Din.Domain.Models.Entities
{
    public class ExpenseGroup
    {
        public Guid Id { get; set; }
        public IEnumerable<Expense> Expenses { get; set; } = new List<Expense>();

        public ExpenseGroup(Guid id)
        {
            Id = id;
        }
        
        public ExpenseGroup() : this(Guid.NewGuid()) { }

        public static ExpenseGroup Build(Expense expense, int times)
        {
            var expenseGroup = new ExpenseGroup();
            var expenseRound = expense.Round;
            for (var i = 1; i <= times; i++)
            {
                var e = new Expense(expense)
                {
                    Name = $"{expense.Name} {i}/{times}",
                    Round = expenseRound,
                    ExpenseGroupId = expenseGroup.Id
                };
                expenseGroup.Expenses = expenseGroup.Expenses.Append(e);
                expenseRound = Round.Next(expenseRound);
            }
            return expenseGroup;
        }
    }
}
