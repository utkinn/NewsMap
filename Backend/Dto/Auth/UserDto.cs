using Microsoft.AspNetCore.Identity;
using NewsMap.Auth;
using NewsMap.Model;

namespace NewsMap.Dto.Auth;

public sealed class UserDto
{
	public static async Task<UserDto> FromModelAsync(User user, UserManager<User> userManager) =>
		new()
		{
			FirstName = user.FirstName,
			LastName = user.LastName,
			Email = user.Email!,
			SubscribedToUpdateNews = user.SubscribedToUpdateNews,
			Notifications = UserNotificationPreferencesDto.FromModel(user.NotificationPreferences),
			TopicPreferences = UserTopicPreferencesDto.FromModel(user.TopicPreferences),
			IsAdmin = await userManager.IsInRoleAsync(user, Roles.Administrator)
		};

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public bool SubscribedToUpdateNews { get; set; }

	public UserNotificationPreferencesDto Notifications { get; set; }

	public UserTopicPreferencesDto TopicPreferences { get; set; }
	
	public bool IsAdmin { get; set; }

	public void UpdateModel(User user)
	{
		user.FirstName = FirstName;
		user.LastName = LastName;
		user.Email = Email;
		user.SubscribedToUpdateNews = SubscribedToUpdateNews;
	}
}