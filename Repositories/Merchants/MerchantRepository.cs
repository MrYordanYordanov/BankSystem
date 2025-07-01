using Domain.Entities;
using Dtos.Common;
using Dtos.Filters;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Merchants;

public class MerchantRepository(BankingDbContext context) : Repository<Merchant>(context), IMerchantRepository
{
    public async Task<PagedResult<Merchant>> GetPagedAsync(PaginationDto pagination)
    {
        var query = dbSet
            .Include(m => m.Transactions)
            .AsQueryable();

        var totalRecords = await query.CountAsync();
        var items = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .AsNoTracking()
            .ToListAsync();

        return new PagedResult<Merchant>
        {
            Items = items,
            PageNumber = pagination.PageNumber,
            PageSize = pagination.PageSize,
            TotalRecords = totalRecords
        };
    }
}
