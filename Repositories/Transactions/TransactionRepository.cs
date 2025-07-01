using Domain.Entities;
using Dtos.Common;
using Dtos.Filters;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
namespace Repositories.Transactions;

public class TransactionRepository(BankingDbContext context)
    : Repository<Transaction>(context), ITransactionRepository
{
    public async Task<PagedResult<Transaction>> GetFilteredAndPagedAsync(TransactionFilterDto filter)
    {
        var query = dbSet.AsQueryable();

        if (filter.StartDate.HasValue) query = query.Where(t => t.CreateDate >= filter.StartDate.Value);
        if (filter.EndDate.HasValue) query = query.Where(t => t.CreateDate <= filter.EndDate.Value);
        if (filter.MinAmount.HasValue) query = query.Where(t => t.Amount >= filter.MinAmount.Value);
        if (filter.MaxAmount.HasValue) query = query.Where(t => t.Amount <= filter.MaxAmount.Value);
        if (filter.Direction.HasValue) query = query.Where(t => t.Direction == filter.Direction.Value);
        if (filter.Status.HasValue) query = query.Where(t => t.Status == filter.Status.Value);

        var totalRecords = await query.CountAsync();
        var items = await query
            .OrderByDescending(t => t.CreateDate)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .AsNoTracking()
            .ToListAsync();

        return new PagedResult<Transaction>
        {
            Items = items,
            PageNumber = filter.PageNumber,
            PageSize = filter.PageSize,
            TotalRecords = totalRecords
        };
    }
}
