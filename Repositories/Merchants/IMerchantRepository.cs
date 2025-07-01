using Domain.Entities;
using Dtos.Common;
using Dtos.Filters;

namespace Repositories.Merchants;

public interface IMerchantRepository : IRepository<Merchant>
{
    Task<PagedResult<Merchant>> GetPagedAsync(PaginationDto pagination);
}
