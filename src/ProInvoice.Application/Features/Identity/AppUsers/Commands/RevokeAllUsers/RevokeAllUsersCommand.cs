using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Abstraction.ResultPattern;
using ProInvoice.Domain.Entities.Identity.Users.DTOs;

namespace ProInvoice.Application.Features.Identity.AppUsers.Commands.RevokeAllUsers;
public record RevokeAllUsersCommand(
    RevokeAllUsersDto Dto) : ICommand<NoContentDto>;
