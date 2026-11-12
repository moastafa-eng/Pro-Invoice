using MediatR;
using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Application.Abstraction.Messaging.Commands;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result<NoContentDto>>
    where TCommand : ICommand;

public interface ICommandHandler<TCommand, TResponse>: IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse: IResult;
