using NewsMap.Model.News;

namespace NewsMap.Dto.Auth;

public sealed class UserNotificationPreferencesDto
{
	public static UserNotificationPreferencesDto FromModel(UserNotificationPreferences preferences) => new()
	{
		Push = preferences.PushNotificationsEnabled,
		NearbyNews = preferences.NotifyAboutNearbyNews,
		ImportantNews = preferences.NotifyAboutImportantNews,
		EmergencyNews = preferences.NotifyAboutEmergencyNews,
	};

	public bool Push { get; set; }
	public bool NearbyNews { get; set; }
	public bool ImportantNews { get; set; }
	public bool EmergencyNews { get; set; }

	public void UpdateModel(UserNotificationPreferences preferences)
	{
		preferences.PushNotificationsEnabled = Push;
		preferences.NotifyAboutNearbyNews = NearbyNews;
		preferences.NotifyAboutImportantNews = ImportantNews;
		preferences.NotifyAboutEmergencyNews = EmergencyNews;
	}
}