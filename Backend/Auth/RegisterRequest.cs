using NewsMap.Model;

namespace NewsMap.Auth;

public sealed class RegisterRequest
{
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public required string Email { get; set; }
	public required string Password { get; set; }
	public required bool SubscribeToUpdates { get; set; }

	public User ToUser() =>
		new()
		{
			FirstName = FirstName,
			LastName = LastName,
			Email = Email,
			SubscribedToUpdateNews = SubscribeToUpdates
		};
}