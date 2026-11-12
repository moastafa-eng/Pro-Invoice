using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Domain.Abstraction;

public interface IINternalServerError
{
    public Error Errors { get; set; }
}