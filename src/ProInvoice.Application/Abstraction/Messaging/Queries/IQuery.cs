using MediatR;
using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Application.Abstraction.Messaging.Queries;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    where TResponse : IResult;