namespace Din.Domain.Requests
{
    public class PinnedExpenseRequest
    {
        public string Name { get; set; }
        public int? DueDay { get; set; }
        public decimal? Value { get; set; }
    }
}
