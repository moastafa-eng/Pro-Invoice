using ProInvoice.Domain.Abstraction;
using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Domain.Exceptions;
public class AdminKeyNotMatchException(
    List<string> errors) : Exception, IBadRequest
{
    public Error Errors { get; set; } = new()
    {
        ErrorCode = "AdminKey.Error",
        ErrorMessages = errors
    };
}
