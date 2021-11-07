using System;

namespace Din.Domain.Models.Entities
{
    public class PinnedExpense
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? DueDay { get; set; }
        public decimal? Value { get; set; }

        public PinnedExpense(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public PinnedExpense(string name) : this(Guid.NewGuid(), name) { }
    }
}
