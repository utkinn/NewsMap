using Microsoft.AspNetCore.Identity;
using NewsMap.Model.News;

namespace NewsMap.Model;

public sealed class User : IdentityUser
{
	public User()
	{
		NotificationPreferences = new UserNotificationPreferences { User = this };
	}

	[PersonalData] public required string FirstName { get; set; }

	[PersonalData] public required string LastName { get; set; }

	public bool SubscribedToUpdateNews { get; set; }

	public UserNotificationPreferences NotificationPreferences { get; init; }

	public List<UserTopicPreference> TopicPreferences { get; set; } = [];
}