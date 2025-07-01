using AutoMapper;
using Dtos.Common;
using Dtos.Merchants;
using MediatR;
using Repositories.Merchants;

namespace BankSystem.Handlers.Merchants.GetPaged;

public class GetPagedMerchantsHandler(
    IMerchantRepository merchantRepository,
    IMapper mapper) : IRequestHandler<GetPagedMerchantsRequest, PagedResult<MerchantDto>>
{
    public async Task<PagedResult<MerchantDto>> Handle(GetPagedMerchantsRequest request, CancellationToken cancellationToken)
    {
        // 1. Get the entities from the repository
        var merchants = await merchantRepository.GetPagedAsync(request.Pagination);

        // 2. Map the PagedResult of entities to a PagedResult of DTOs
        var merchantDtos = mapper.Map<PagedResult<MerchantDto>>(merchants);

        return merchantDtos;
    }
}
