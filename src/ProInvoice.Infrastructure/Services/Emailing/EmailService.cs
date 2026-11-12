using ProInvoice.Application.Abstraction.Emailing;

namespace ProInvoice.Infrastructure.Services.Emailing;
public class EmailService : IEmailService
{
    public Task SendAsync()
    {
        return Task.CompletedTask;
    }
}
