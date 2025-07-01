using AutoMapper;
using Dtos.Common;
using Dtos.Transactions;
using MediatR;
using Repositories.Transactions;

namespace BankSystem.Handlers.Transactions.GetPaged;

public class GetPagedTransactionsHandler(
    ITransactionRepository transactionRepository,
    IMapper mapper) : IRequestHandler<GetPagedTransactionsRequest, PagedResult<TransactionDto>>
{
    public async Task<PagedResult<TransactionDto>> Handle(GetPagedTransactionsRequest request, CancellationToken cancellationToken)
    {
        var transactions = await transactionRepository.GetFilteredAndPagedAsync(request.Filter);
        var transactionDtos = mapper.Map<PagedResult<TransactionDto>>(transactions);

        return transactionDtos;
    }
}
