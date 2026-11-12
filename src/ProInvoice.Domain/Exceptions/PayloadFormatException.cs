using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Domain.Exceptions;
public class PayloadFormatException(
    List<string> errors) : Exception, IBadRequest
{
    public Error Errors { get; set; } = new()
    {
        ErrorCode = "PayloadFormat.Error",
        ErrorMessages = errors
    };
}