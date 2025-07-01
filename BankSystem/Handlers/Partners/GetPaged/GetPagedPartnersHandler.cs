using AutoMapper;
using Dtos.Common;
using Dtos.Partners;
using MediatR;
using Repositories.Partners;

namespace BankSystem.Handlers.Partners.GetPaged;

public class GetPagedPartnersHandler(
    IPartnerRepository partnerRepository,
    IMapper mapper) : IRequestHandler<GetPagedPartnersRequest, PagedResult<PartnerDto>>
{
    public async Task<PagedResult<PartnerDto>> Handle(GetPagedPartnersRequest request, CancellationToken cancellationToken)
    {
        // 1. Get the entities from the repository
        var partners = await partnerRepository.GetPagedAsync(request.Pagination);

        // 2. Map the PagedResult of entities to a PagedResult of DTOs
        var partnerDtos = mapper.Map<PagedResult<PartnerDto>>(partners);

        return partnerDtos;
    }
}
