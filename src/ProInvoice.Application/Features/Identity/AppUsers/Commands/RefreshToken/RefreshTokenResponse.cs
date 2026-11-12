using ProInvoice.Domain.Abstraction.ResultPattern;

namespace ProInvoice.Application.Features.Identity.AppUsers.Commands.RefreshToken;
public class RefreshTokenResponse : IResult
{
    public string NewAccessToken { get; set; } = null!;
    public string NewRefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpireDate { get; set; }
}
