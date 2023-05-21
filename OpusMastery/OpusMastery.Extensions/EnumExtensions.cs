namespace OpusMastery.Extensions;

public static class EnumExtensions
{
    public static string ToEnumName<T>(this T enumValue) where T : struct, Enum
    {
        return Enum.GetName(enumValue).ThrowIfNull(new ArgumentNullException(nameof(enumValue)));
    }
}