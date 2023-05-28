using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace OpusMastery.Middlewares;

public partial class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        return value is not null ? ControllerRouteRegex().Replace(value.ToString()!, "$1-$2").ToLower() : null;
    }

    [GeneratedRegex("([a-z])([A-Z])", RegexOptions.Compiled)]
    private static partial Regex ControllerRouteRegex();
}