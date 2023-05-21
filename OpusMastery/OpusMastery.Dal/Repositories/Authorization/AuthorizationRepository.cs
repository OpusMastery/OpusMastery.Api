using Microsoft.EntityFrameworkCore;
using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Dal.Models;
using OpusMastery.Domain.Authorization;
using OpusMastery.Domain.Authorization.Interfaces;

namespace OpusMastery.Dal.Repositories.Authorization;

public class AuthorizationRepository : IAuthorizationRepository
{
    private readonly IDatabaseContext _databaseContext;

    public AuthorizationRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<bool> IsUserExistsByEmailAsync(string email)
    {
        return await _databaseContext.Set<SystemUser>()
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email) is not null;
    }

    public async Task<Guid> SaveNewUserAsync(User user)
    {
        var systemUser = user.ToDal();
        
        await _databaseContext.AddAsync(systemUser);
        await _databaseContext.SaveAsync();
        
        return systemUser.Id;
    }
}