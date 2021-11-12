using System;
using Din.Domain.Abstractions.Requests;

namespace Din.Domain.Requests
{
    public class ExpenseRequest : ExpenseBaseRequest
    {
        public Guid? PinnedExpenseId { get; set; }
    }
}
