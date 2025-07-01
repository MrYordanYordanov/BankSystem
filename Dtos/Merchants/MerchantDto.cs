using Dtos.Transactions;

namespace Dtos.Merchants;

public class MerchantDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BoardingDate { get; set; }
    public string Url { get; set; }

    public string Country { get; set; }

    public string Address_1 { get; set; }

    public string Address_2 { get; set; }

    public int PartnerId { get; set; }

    public ICollection<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
}