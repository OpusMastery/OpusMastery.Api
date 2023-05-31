using Microsoft.IdentityModel.Tokens;
using OpusMastery.Extensions;

namespace OpusMastery.Application.Extensions;

public static class JwtExtensions
{
    public static SymmetricSecurityKey GetSecurityKey(this string secretKey)
    {
        return new SymmetricSecurityKey(secretKey.ToByteArray());
    }
}