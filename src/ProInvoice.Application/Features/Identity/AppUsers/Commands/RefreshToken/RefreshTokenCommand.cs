using ProInvoice.Application.Abstraction.Messaging.Commands;
using ProInvoice.Domain.Entities.Identity.Users.DTOs;

namespace ProInvoice.Application.Features.Identity.AppUsers.Commands.RefreshToken;
public record RefreshTokenCommand(
    RefreshTokenDto Dto) : ICommand<RefreshTokenResponse>;