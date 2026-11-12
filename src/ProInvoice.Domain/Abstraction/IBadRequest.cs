using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Domain.Abstraction;

public interface IBadRequest
{
    public Error Errors { get; set; }
}