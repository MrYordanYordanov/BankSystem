using Domain.Enums;

namespace Dtos.Filters;

public class TransactionFilterDto : PaginationDto
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? MinAmount { get; set; }
    public decimal? MaxAmount { get; set; }
    public TransactionDirection? Direction { get; set; }
    public TransactionStatus? Status { get; set; }
}
