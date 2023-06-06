namespace OpusMastery.Extensions;

public static class CollectionExtensions
{
    public static List<T> OrEmptyIfNull<T>(this IEnumerable<T>? collection)
    {
        return collection?.ToList() ?? new List<T>();
    }
}