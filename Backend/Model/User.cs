using Microsoft.AspNetCore.Identity;

namespace NewsMap.Model;

public sealed class User : IdentityUser
{
	[PersonalData]
	public required string FirstName { get; set; }
	
	[PersonalData]
	public required string LastName { get; set; }
	
	public bool SubscribedToUpdateNews { get; set; }
}