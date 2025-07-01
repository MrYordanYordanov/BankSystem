using Dtos.Files;
using MediatR;
using Services.Reports;

namespace BankSystem.Handlers.Transactions.Export;

public class ExportTransactionsHandler(IReportingService reportingService) : IRequestHandler<ExportTransactionsRequest, FileResult>
{
    public async Task<FileResult> Handle(ExportTransactionsRequest request, CancellationToken cancellationToken)
    {
        var fileBytes = await reportingService.ExportTransactionsToCsvAsync();

        return new FileResult
        {
            FileBytes = fileBytes,
            ContentType = "text/csv",
            FileName = "transactions.csv",
        };
    }
}
