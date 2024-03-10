using NewsMap.Dto.Auth;
using NewsMap.Model;

namespace NewsMap.Dto;

public sealed class UserResponse(User user)
{
	public string FirstName => user.FirstName;
	public string LastName => user.LastName;
	public string Email => user.Email!;
	public bool SubscribedToUpdateNews => user.SubscribedToUpdateNews;

	public UserNotificationPreferencesResponse Notifications =>
		new UserNotificationPreferencesResponse(user.NotificationPreferences);
	
	public UserTopicPreferencesResponse TopicPreferences =>
		new UserTopicPreferencesResponse(user.TopicPreferences);
}