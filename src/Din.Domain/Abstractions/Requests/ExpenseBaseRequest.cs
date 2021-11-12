using Din.Domain.Models.Enumerations;

namespace Din.Domain.Abstractions.Requests
{
    public abstract class ExpenseBaseRequest
    {
        public string Name { get; set; }
        public int? Year { get; set; }
        public Month? Month { get; set; }
        public int? DueDay { get; set; }
        public decimal? Value { get; set; }
    }
}
