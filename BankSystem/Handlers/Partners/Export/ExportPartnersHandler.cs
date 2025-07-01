using Dtos.Files;
using MediatR;
using Services.Reports;

namespace BankSystem.Handlers.Partners.Export;

public class ExportPartnersHandler(IReportingService reportingService) : IRequestHandler<ExportPartnersRequest, FileResult>
{
    public async Task<FileResult> Handle(ExportPartnersRequest request, CancellationToken cancellationToken)
    {
        var fileBytes = await reportingService.ExportPartnersToCsvAsync();

        return new FileResult
        {
            FileBytes = fileBytes,
            ContentType = "text/csv",
            FileName = "partners.csv",
        };
    }
}
