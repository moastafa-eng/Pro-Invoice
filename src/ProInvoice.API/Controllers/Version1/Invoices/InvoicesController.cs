using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProInvoice.Application.Features.Invoices.Commands.CreateInvoice;
using ProInvoice.Application.Features.Invoices.Commands.RemoveInvoice;
using ProInvoice.Application.Features.Invoices.Commands.UpdateInvoice;
using ProInvoice.Application.Features.Invoices.Queries.GetAllInvoices;
using ProInvoice.Application.Features.Invoices.Queries.GetInvoice;
using ProInvoice.Domain.Entities.Invoices.DTOs;

namespace ProInvoice.API.Controllers.Version1.Invoices;

[Authorize]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class InvoicesController(ISender sender) : BaseController
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> CreateInvoiceAsync(
    CreateInvoiceDto request,
    CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new CreateInvoiceCommand(request),
            cancellationToken);
        return CreateResult(response);
    }

    [HttpGet("{invoiceId}")]
    public async Task<IActionResult> GetInvoiceAsync(
        Guid invoiceId,
        CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new GetInvoiceQuery(invoiceId),
            cancellationToken);

        return CreateResult(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInvoiceAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new GetAllInvoicesQuery(),
            cancellationToken);

        return CreateResult(response);
    }

    [HttpPut("{invoiceId}")]
    public async Task<IActionResult> UpdateInvoiceAsync(
        Guid invoiceId,
        UpdateInvoiceDto request,
        CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new UpdateInvoiceCommand(invoiceId, request),
            cancellationToken);

        return CreateResult(response);
    }

    [HttpDelete("{invoiceId}")]
    public async Task<IActionResult> RemoveInvoiceAsync(
       Guid invoiceId,
       CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new RemoveInvoiceCommand(invoiceId),
            cancellationToken);

        return CreateResult(response);
    }
}
