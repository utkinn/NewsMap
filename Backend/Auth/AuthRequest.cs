namespace NewsMap.Auth;

public sealed record AuthRequest
{
    public required string UserName { get; init; }
    public required string Password { get; init; }
}