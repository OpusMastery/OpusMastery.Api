using OpusMastery.Domain.Identity;

namespace OpusMastery.Admin.Controllers.V1.Identity.Dto;

public static class Converter
{
    public static DemoUser ToDomain(this DemoUserRegistrationDto demoUserRegistrationDto)
    {
        return DemoUser.CreateNew(
            demoUserRegistrationDto.Email.ToLower(),
            demoUserRegistrationDto.Password,
            demoUserRegistrationDto.FirstName,
            demoUserRegistrationDto.LastName);
    }
}