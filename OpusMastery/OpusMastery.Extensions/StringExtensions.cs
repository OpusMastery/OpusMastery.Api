using System.Security.Cryptography;
using System.Text;

namespace OpusMastery.Extensions;

public static class StringExtensions
{
    public static string ToSha512(this string value)
    {
        return SHA512.HashData(value.ToByteArray()).ToHexString();
    }

    public static byte[] ToByteArray(this string value)
    {
        return Encoding.UTF8.GetBytes(value);
    }

    public static string ToHexString(this IEnumerable<byte> bytes, bool toUpperCase = false)
    {
        return new string(bytes.SelectMany(b => b.ToString(toUpperCase ? "X2" : "x2")).ToArray());
    }

    public static Guid? ToGuidOrDefault(this string? value)
    {
        return Guid.TryParse(value, out Guid result) ? result : null;
    }
}