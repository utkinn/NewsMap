using NewsMap.Model.News;

namespace NewsMap.Dto.Auth;

public sealed class UserNotificationPreferencesResponse(UserNotificationPreferences preferences)
{
	public bool Push => preferences.PushNotificationsEnabled;
	public bool NearbyNews => preferences.NotifyAboutNearbyNews;
	public bool ImportantNews => preferences.NotifyAboutImportantNews;
	public bool EmergencyNews => preferences.NotifyAboutEmergencyNews;
}