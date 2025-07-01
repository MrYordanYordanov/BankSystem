using Domain.Entities;
using Dtos.Common;
using Dtos.Filters;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Partners;

internal class PartnerRepository(BankingDbContext context) : Repository<Partner>(context), IPartnerRepository
{
    public async Task<PagedResult<Partner>> GetPagedAsync(PaginationDto pagination)
    {
        var query = dbSet
                .Include(p => p.Merchants)
                .AsQueryable();

        var totalRecords = await query.CountAsync();
        var items = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .AsNoTracking()
            .ToListAsync();

        return new PagedResult<Partner>
        {
            Items = items,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize,
            TotalRecords = totalRecords
        };
    }
}
