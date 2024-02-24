using Microsoft.AspNetCore.Identity;

namespace NewsMap.Auth;

public sealed class User : IdentityUser
{
	[PersonalData]
	public required string FirstName { get; set; }
	
	[PersonalData]
	public required string LastName { get; set; }
	
	public bool SubscribedToUpdateNews { get; set; }
}