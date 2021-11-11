using System;
using Din.Domain.Models.Enumerations;

namespace Din.Domain.Requests
{
    public class ExpenseRequest
    {
        public string Name { get; set; }
        public int? Year { get; set; }
        public Month? Month { get; set; }
        public int? DueDay { get; set; }
        public decimal? Value { get; set; }
        public Guid? PinnedExpenseId { get; set; }
    }
}
