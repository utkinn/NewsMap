namespace NewsMap.Auth;

public sealed class ChangePasswordRequest
{
	public required string CurrentPassword { get; set; }
	public required string NewPassword { get; set; }
}