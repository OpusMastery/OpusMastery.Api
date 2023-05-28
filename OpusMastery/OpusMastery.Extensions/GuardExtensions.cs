using System.Diagnostics.CodeAnalysis;

namespace OpusMastery.Extensions;

public static class GuardExtensions
{
    public static T ThrowIfNull<T>([NotNull] this T? value, Func<Exception> exceptionFactory)
    {
        return value is null ? throw exceptionFactory() : value;
    }

    public static void ThrowIfTrue(this bool value, Func<Exception> exceptionFactory)
    {
        if (value)
        {
            throw exceptionFactory();
        }
    }
}