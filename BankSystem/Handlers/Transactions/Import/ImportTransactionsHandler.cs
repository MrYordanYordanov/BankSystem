using MediatR;
using Services.ErrorHandling;
using Services.Reports;

namespace BankSystem.Handlers.Transactions.Import;

public class ImportTransactionsHandler(
    IReportingService reportingService,
    IGuard guard) : IRequestHandler<ImportTransactionsRequest>
{
    public async Task Handle(ImportTransactionsRequest request, CancellationToken cancellationToken)
    {
        guard.AgainstTrue(request.File.Length == 0, "Error invalid file!");

        await using var stream = request.File.OpenReadStream();

        await reportingService.ImportTransactionsFromXmlStreamAsync(stream, cancellationToken);
    }
}
