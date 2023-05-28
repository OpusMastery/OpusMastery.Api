namespace OpusMastery.Extensions;

public static class EnumExtensions
{
    public static string ToEnumName<T>(this T enumValue) where T : struct, Enum
    {
        return Enum.GetName(enumValue).ThrowIfNull(new ArgumentOutOfRangeException(nameof(enumValue)));
    }

    public static int ToInt32<T>(this T enumValue) where T : struct, Enum
    {
        return Convert.ToInt32(enumValue);
    }
}