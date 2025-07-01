using BankSystem.Handlers.Merchants.Export;
using BankSystem.Handlers.Merchants.GetPaged;
using Dtos.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

[Route("api/[controller]")]
public class MerchantsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPagedMerchants([FromQuery] PaginationDto pagination)
    {
        var query = new GetPagedMerchantsRequest { Pagination = pagination };
        var result = await sender.Send(query);
        return Ok(result);
    }


    [HttpGet("export")]
    public async Task<IActionResult> ExportMerchants()
    {
        var request = new ExportMerchantsRequest();
        var fileResult = await sender.Send(request);

        return File(fileResult.FileBytes, fileResult.ContentType, fileResult.FileName);
    }
}
