using System.ComponentModel.DataAnnotations;

namespace NewsMap.Auth;

public sealed record JwtOptions
{
    public const string SectionName = "Jwt";

    [Required] public required string Issuer { get; init; }
    [Required] public required string Audience { get; init; }
    [Required] public required byte[] Key { get; init; }
    [Required] public required TimeSpan Lifetime { get; init; }
}