using OpusMastery.Domain.Identity;

namespace OpusMastery.Domain.Email.Interfaces;

public interface IEmailSender
{
    public Task SendAsync(User user);
}