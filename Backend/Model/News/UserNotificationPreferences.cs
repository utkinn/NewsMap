using Microsoft.EntityFrameworkCore;

namespace NewsMap.Model.News;

[PrimaryKey(nameof(UserId))]
public sealed class UserNotificationPreferences
{
	public string UserId { get; private set; }
	public required User User { get; init; }

	public bool PushNotificationsEnabled { get; set; }
	public bool NotifyAboutNearbyNews { get; set; }
	public bool NotifyAboutImportantNews { get; set; }
	public bool NotifyAboutEmergencyNews { get; set; }
}