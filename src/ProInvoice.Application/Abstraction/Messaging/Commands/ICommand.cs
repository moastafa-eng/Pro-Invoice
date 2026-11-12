using MediatR;
using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Application.Abstraction.Messaging.Commands;
public interface ICommand : IRequest<Result<NoContentDto>>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    where TResponse : IResult;


