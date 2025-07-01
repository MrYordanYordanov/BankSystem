using BankSystem.Handlers.Partners.Export;
using BankSystem.Handlers.Partners.GetPaged;
using Dtos.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

[Route("api/[controller]")]
public class PartnersController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPagedPartners([FromQuery] PaginationDto pagination)
    {
        var query = new GetPagedPartnersRequest { Pagination = pagination };
        var result = await sender.Send(query);
        return Ok(result);
    }

    [HttpGet("export")]
    public async Task<IActionResult> ExportPartners()
    {
        var request = new ExportPartnersRequest();
        var fileResult = await sender.Send(request);

        return File(fileResult.FileBytes, fileResult.ContentType, fileResult.FileName);
    }
}
