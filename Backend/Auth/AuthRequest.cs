namespace NewsMap.Auth;

public sealed record AuthRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}