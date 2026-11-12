using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Entities.Identity.Users.DTOs;

namespace ProInvoice.Application.Features.Identity.AppUsers.Commands.LoginUser;
public record LoginUserCommand(
    LoginUserDto Dto) : ICommand<LoginUserResponse>;
