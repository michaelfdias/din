using System;

namespace Din.Domain.Models.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Round Round { get; set; }
        public int? DueDay { get; set; }
        public decimal? Value { get; set; }
        public bool IsPaid { get; set; }
        public Guid? PinnedExpenseId { get; set; }

        public Expense(Guid id, string name, Round round)
        {
            Id = id;
            Name = name;
            Round = round;
        }
        
        public Expense(string name, Round round) : this(Guid.NewGuid(), name, round) { }
    }
}
