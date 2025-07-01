using Dtos.Files;
using MediatR;
using Services.Reports;

namespace BankSystem.Handlers.Merchants.Export;

public class ExportMerchantsHandler(IReportingService reportingService) : IRequestHandler<ExportMerchantsRequest, FileResult>
{
    public async Task<FileResult> Handle(ExportMerchantsRequest request, CancellationToken cancellationToken)
    {
        var fileBytes = await reportingService.ExportMerchantsToCsvAsync();

        return new FileResult
        {
            FileBytes = fileBytes,
            ContentType = "text/csv",
            FileName = "merchants.csv",
        };
    }
}
