using NewsMap.Dto.News;
using NewsMap.Model.News;

namespace NewsMap.Dto.Auth;

public sealed class UserTopicPreferencesResponse(IEnumerable<UserTopicPreference> preferences)
{
	public IEnumerable<ArticleTagResponse> Important => GetPreferencesByType(UserTopicPreferenceType.Important);

	public IEnumerable<ArticleTagResponse> Interesting => GetPreferencesByType(UserTopicPreferenceType.Interesting);

	public IEnumerable<ArticleTagResponse> Hidden => GetPreferencesByType(UserTopicPreferenceType.Hidden);

	private IEnumerable<ArticleTagResponse> GetPreferencesByType(UserTopicPreferenceType type) =>
		preferences
			.Where(p => p.Type == type)
			.Select(p => new ArticleTagResponse(p.Tag));
}