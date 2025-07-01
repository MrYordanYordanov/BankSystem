using Dtos.Files;
using MediatR;

namespace BankSystem.Handlers.Partners.Export;

public class ExportPartnersRequest : IRequest<FileResult>
{
}
