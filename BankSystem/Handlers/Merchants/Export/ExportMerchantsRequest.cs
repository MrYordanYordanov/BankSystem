using Dtos.Files;
using MediatR;

namespace BankSystem.Handlers.Merchants.Export;

public class ExportMerchantsRequest : IRequest<FileResult>
{
}
