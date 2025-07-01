using AutoMapper;
using Domain.Entities;
using Dtos.Common;
using Dtos.Merchants;
using Dtos.Partners;
using Dtos.Transactions;

namespace BankSystem.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Partner, PartnerDto>();
        CreateMap<Merchant, MerchantDto>();
        CreateMap<Transaction, TransactionDto>();

        CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));
    }
}