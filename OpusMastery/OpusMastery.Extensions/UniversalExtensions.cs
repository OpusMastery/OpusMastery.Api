using System.Diagnostics.CodeAnalysis;

namespace OpusMastery.Extensions;

public static class UniversalExtensions
{
    public static T ThrowIfNull<T>([NotNull] this T? value, Exception exception)
    {
        return value is null ? throw exception : value;
    }
}