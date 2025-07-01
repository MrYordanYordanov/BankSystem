using CsvHelper;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Database.Unit;
using Repositories.Merchants;
using Repositories.Partners;
using Repositories.Transactions;
using Services.XmlModels.Transactions;
using System.Globalization;
using System.Xml.Serialization;

namespace Services.Reports;

public class ReportingService(
    IPartnerRepository partnerRepository,
    IMerchantRepository merchantRepository,
    ITransactionRepository transactionRepository,
    IUnitOfWork unitOfWork) : IReportingService
{
    public async Task ImportTransactionsFromXmlStreamAsync(Stream stream, CancellationToken cancellationToken)
    {
        var serializer = new XmlSerializer(typeof(XmlOperation));
        var xmlOperation = (XmlOperation)serializer.Deserialize(stream);

        var transactions = xmlOperation.Transactions.Select(xt => new Transaction
        {
            Id = Guid.NewGuid(),
            ExternalId = xt.ExternalId,
            CreateDate = xt.CreateDate,
            Amount = xt.Amount.Value,
            Currency = xt.Amount.Currency,
            Direction = xt.Amount.Direction == "D" ? TransactionDirection.Debit : TransactionDirection.Credit,
            Status = xt.Status == 1 ? TransactionStatus.Successful : TransactionStatus.Failed,
            DebtorIBAN = xt.Debtor.IBAN,
            BeneficiaryIBAN = xt.Beneficiary.IBAN,
        }).ToList();

        // Use the repository to add the new entities
        await transactionRepository.AddRangeAsync(transactions);

        // Use the Unit of Work to save all changes in a single transaction
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<byte[]> ExportPartnersToCsvAsync()
    {
        var records = await partnerRepository.GetAllAsync();
        return await GenerateCsv(records);
    }

    public async Task<byte[]> ExportMerchantsToCsvAsync()
    {
        var records = await merchantRepository.GetAllAsync();
        return await GenerateCsv(records);
    }

    public async Task<byte[]> ExportTransactionsToCsvAsync()
    {
        var records = await transactionRepository.GetAllAsync();
        return await GenerateCsv(records);
    }

    private async Task<byte[]> GenerateCsv<T>(IEnumerable<T> records)
    {
        using var memoryStream = new MemoryStream();
        using (var writer = new StreamWriter(memoryStream))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            await csv.WriteRecordsAsync(records);
        }
        return memoryStream.ToArray();
    }

}
