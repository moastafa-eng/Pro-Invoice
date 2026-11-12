using Microsoft.AspNetCore.Mvc;
using ProInvoice.Domain.Abstraction.ResultPattern;
using Abstraction = ProInvoice.Domain.Abstraction;

namespace ProInvoice.API.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    public IActionResult CreateResult<TDto>(
        Result<TDto> result) 
        where TDto : Abstraction.ResultPattern.IResult
        => result.StatusCode == 204
            ? new ObjectResult(null) { StatusCode = 204}
            : new ObjectResult(result) { StatusCode = result.StatusCode };    
}
