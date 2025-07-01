using Dtos.Common;
using Dtos.Filters;
using Dtos.Partners;
using MediatR;

namespace BankSystem.Handlers.Partners.GetPaged;

public class GetPagedPartnersRequest : IRequest<PagedResult<PartnerDto>>
{
    public PaginationDto Pagination { get; set; }
}
