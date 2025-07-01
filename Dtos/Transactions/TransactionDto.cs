using Domain.Enums;

namespace Dtos.Transactions;

public class TransactionDto
{
    public Guid Id { get; set; }

    public string ExternalId { get; set; }

    public DateTime CreateDate { get; set; }

    public TransactionDirection Direction { get; set; }
    public decimal Amount { get; set; }

    public string Currency { get; set; }

    public string DebtorIBAN { get; set; }

    public string BeneficiaryIBAN { get; set; }

    public TransactionStatus Status { get; set; }

    public int MerchantId { get; set; }
}
