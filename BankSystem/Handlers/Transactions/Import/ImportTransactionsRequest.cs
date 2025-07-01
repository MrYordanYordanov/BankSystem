using MediatR;

namespace BankSystem.Handlers.Transactions.Import;

public class ImportTransactionsRequest : IRequest
{
    public IFormFile File { get; set; }
}
