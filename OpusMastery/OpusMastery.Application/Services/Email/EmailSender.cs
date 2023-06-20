using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using OpusMastery.Domain.Email.Interfaces;
using OpusMastery.Domain.Identity;

namespace OpusMastery.Application.Services.Email;

public class EmailSender : IEmailSender
{
    public async Task SendAsync(User user)
    {
        MimeMessage emailMessage = new();

        emailMessage.From.Add(new MailboxAddress("OpusMastery", "support@opusmastery.org"));
        emailMessage.To.Add(new MailboxAddress(user.FullName, user.Email));

        emailMessage.Subject = "OpusMastery Company Creation";
        emailMessage.Body = new TextPart(TextFormat.Html)
        {
            Text =
"""
<!DOCTYPE html>
<html>
    <body>
        <h1>Hello, world!</h1>
        <p>This is your first email.</p>
        <a href="https://google.com/" style="display: inline-block; padding: 10px 20px; color: #fff; background-color: #007bff; border-radius: 5px; text-decoration: none;">Go to Google</a>
    </body>
</html>
"""
        };

        using var emailClient = new SmtpClient();

        await emailClient.ConnectAsync("smtp.porkbun.com", 587, SecureSocketOptions.StartTls);
        await emailClient.AuthenticateAsync("support@opusmastery.org", "Freedom1");

        await emailClient.SendAsync(emailMessage);
        await emailClient.DisconnectAsync(true);
    }
}