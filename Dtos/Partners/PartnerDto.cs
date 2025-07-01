using Dtos.Merchants;

namespace Dtos.Partners;

public class PartnerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<MerchantDto> Merchants { get; set; } = new List<MerchantDto>();
}
