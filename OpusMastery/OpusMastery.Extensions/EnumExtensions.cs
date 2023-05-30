namespace OpusMastery.Extensions;

public static class EnumExtensions
{
    public static TEnum ToEnum<TEnum>(this string? value) where TEnum : struct, Enum
    {
        return Enum.TryParse(value, out TEnum enumValue) ? enumValue : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public static string ToEnumName<TEnum>(this TEnum enumValue) where TEnum : struct, Enum
    {
        return Enum.GetName(enumValue).ThrowIfNull(() => new ArgumentOutOfRangeException(nameof(enumValue)));
    }

    public static int ToInt32<TEnum>(this TEnum enumValue) where TEnum : struct, Enum
    {
        return Convert.ToInt32(enumValue);
    }
}