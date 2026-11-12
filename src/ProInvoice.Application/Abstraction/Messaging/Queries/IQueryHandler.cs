using MediatR;
using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Application.Abstraction.Messaging.Queries;
public interface IQueryHandler<TQuery ,TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse: IResult;