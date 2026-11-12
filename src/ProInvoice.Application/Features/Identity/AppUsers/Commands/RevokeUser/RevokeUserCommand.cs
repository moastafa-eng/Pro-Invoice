using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Identity.Users.DTOs;

namespace ProInvoice.Application.Features.Identity.AppUsers.Commands.RevokeUser;
public record RevokeUserCommand(
    RevokeUserDto Dto) : ICommand<NoContentDto>;
