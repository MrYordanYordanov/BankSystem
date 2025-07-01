using Dtos.Files;
using MediatR;

namespace BankSystem.Handlers.Transactions.Export;

public class ExportTransactionsRequest : IRequest<FileResult>
{
}
