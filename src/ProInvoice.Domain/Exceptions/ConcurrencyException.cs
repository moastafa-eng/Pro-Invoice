using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Domain.Exceptions;
public class ConcurrencyException(
    List<string> errors) : Exception, IBadRequest
{
    public Error Errors { get; set; } = new()
    {
        ErrorCode = "Concurrency.Error",
        ErrorMessages = errors
    };
}
