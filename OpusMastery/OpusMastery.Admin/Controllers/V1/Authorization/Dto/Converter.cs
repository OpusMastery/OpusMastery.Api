using OpusMastery.Domain.Authorization;

namespace OpusMastery.Admin.Controllers.V1.Authorization.Dto;

public static class Converter
{
    public static User ToDomain(this DemoUserDto demoUserDto)
    {
        return User.CreateNew(demoUserDto.Email.ToLower(), demoUserDto.FirstName, demoUserDto.LastName);
    }
}