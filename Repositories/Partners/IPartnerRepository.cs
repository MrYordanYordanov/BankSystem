using Domain.Entities;
using Dtos.Common;
using Dtos.Filters;

namespace Repositories.Partners;

public interface IPartnerRepository : IRepository<Partner>
{
    Task<PagedResult<Partner>> GetPagedAsync(PaginationDto pagination);
}
