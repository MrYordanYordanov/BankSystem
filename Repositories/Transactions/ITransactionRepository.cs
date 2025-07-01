using Domain.Entities;
using Dtos.Common;
using Dtos.Filters;

namespace Repositories.Transactions;

public interface ITransactionRepository : IRepository<Transaction>
{
    Task<PagedResult<Transaction>> GetFilteredAndPagedAsync(TransactionFilterDto filter);
}