using Dtos.Common;
using Dtos.Filters;
using Dtos.Merchants;
using MediatR;

namespace BankSystem.Handlers.Merchants.GetPaged;

public class GetPagedMerchantsRequest : IRequest<PagedResult<MerchantDto>>
{
    public PaginationDto Pagination { get; set; }
}
