using Din.Domain.Abstractions.Requests;

namespace Din.Domain.Requests
{
    public class ExpenseGroupRequest : ExpenseBaseRequest
    {
        public int Times { get; set; }
    }
}
