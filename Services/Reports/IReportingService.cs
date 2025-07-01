
namespace Services.Reports;

public interface IReportingService
{
    Task ImportTransactionsFromXmlStreamAsync(Stream stream, CancellationToken cancellationToken);
    Task<byte[]> ExportPartnersToCsvAsync();
    Task<byte[]> ExportMerchantsToCsvAsync();
    Task<byte[]> ExportTransactionsToCsvAsync();
}
