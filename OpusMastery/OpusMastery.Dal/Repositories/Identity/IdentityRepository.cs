using Microsoft.EntityFrameworkCore;
using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Dal.Models;
using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Identity.Interfaces;

namespace OpusMastery.Dal.Repositories.Identity;

public class IdentityRepository : IIdentityRepository
{
    private readonly IDatabaseContext _databaseContext;

    public IdentityRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<bool> IsUserExistsByEmailAsync(string email)
    {
        return await _databaseContext.Set<SystemUser>()
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email) is not null;
    }

    public async Task<Guid> SaveNewUserAsync(DemoUser demoUser)
    {
        var systemUser = demoUser.ToDal();
        await _databaseContext.SaveNewAsync(systemUser);
        return systemUser.Id;
    }
}