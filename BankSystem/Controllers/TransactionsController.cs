using BankSystem.Handlers.Transactions.Export;
using BankSystem.Handlers.Transactions.GetPaged;
using BankSystem.Handlers.Transactions.Import;
using Dtos.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

[Route("api/[controller]")]
public class TransactionsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPagedTransactions([FromQuery] TransactionFilterDto filter)
    {
        var query = new GetPagedTransactionsRequest { Filter = filter };
        var result = await sender.Send(query);
        return Ok(result);
    }

    [HttpGet("export")]
    public async Task<IActionResult> ExportTransactions()
    {
        var request = new ExportTransactionsRequest();
        var fileResult = await sender.Send(request);

        return File(fileResult.FileBytes, fileResult.ContentType, fileResult.FileName);
    }

    [HttpPost("import")]
    public async Task<IActionResult> ImportTransactions(IFormFile file)
    {
        var request = new ImportTransactionsRequest {  File = file };

        await sender.Send(request);
        return NoContent();
    }
}
