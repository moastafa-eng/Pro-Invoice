using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProInvoice.Application.Features.Customers.Commands.CreateCustomer;
using ProInvoice.Application.Features.Customers.Commands.RemoveCustomer;
using ProInvoice.Application.Features.Customers.Commands.UpdateCustomer;
using ProInvoice.Application.Features.Customers.Queries.GetAllCustomers;
using ProInvoice.Application.Features.Customers.Queries.GetCustomer;
using ProInvoice.Domain.Entities.Customers.DTOs;
using ProInvoice.Domain.Exceptions;

namespace ProInvoice.API.Controllers.Version1.Customers;

[Authorize]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CustomersController(
    ISender sender) : BaseController
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync(
        CreateCustomerDto request,
        CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new CreateCustomerCommand(request),
            cancellationToken);

        return CreateResult(response);
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new GetCustomerQuery(customerId),
            cancellationToken);

        return CreateResult(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomerAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new GetAllCustomersQuery(),
            cancellationToken);

        return CreateResult(response);
    }   

    [HttpPut("{customerId}")]
    public async Task<IActionResult> UpdateCustomerAsync(
        Guid customerId,
        UpdateCustomerDto request,
        CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new UpdateCustomerCommand(customerId,request),
            cancellationToken);

        return CreateResult(response);
    }

    [HttpDelete("{customerId}")]
    public async Task<IActionResult> RemoveCustomerAsync(
       Guid customerId,
       CancellationToken cancellationToken = default)
    {
        var response = await _sender.Send(
            new RemoveCustomerCommand(customerId),
            cancellationToken);

        return CreateResult(response);
    }
}
