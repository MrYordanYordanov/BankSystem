using Dtos.Common;
using Dtos.Filters;
using Dtos.Transactions;
using MediatR;

namespace BankSystem.Handlers.Transactions.GetPaged;

public class GetPagedTransactionsRequest : IRequest<PagedResult<TransactionDto>>
{
    public TransactionFilterDto Filter { get; set; }
}
