using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Domain.Exceptions;
public class InternalServerException(
    string errorCode,
    List<string> errors) : Exception, IINternalServerError
{
    public Error Errors { get; set; } = new()
    {
        ErrorCode = errorCode,
        ErrorMessages = errors
    };
}
