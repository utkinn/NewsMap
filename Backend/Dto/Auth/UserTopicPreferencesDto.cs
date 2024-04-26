using NewsMap.Dto.News;
using NewsMap.Model;
using NewsMap.Model.News;

namespace NewsMap.Dto.Auth;

public sealed class UserTopicPreferencesDto
{
	public static UserTopicPreferencesDto FromModel(IEnumerable<UserTopicPreference> preferences)
	{
		var preferencesByType = preferences.GroupBy(p => p.Type)
			.ToDictionary(g => g.Key, g => g.Select(p => new ArticleTagResponse(p.Tag)));
		return new UserTopicPreferencesDto
		{
			Important = preferencesByType.GetValueOrDefault(UserTopicPreferenceType.Important) ?? [],
			Interesting = preferencesByType.GetValueOrDefault(UserTopicPreferenceType.Interesting) ?? [],
			Hidden = preferencesByType.GetValueOrDefault(UserTopicPreferenceType.Hidden) ?? [],
		};
	}

	public IEnumerable<ArticleTagResponse> Important { get; set; } = Enumerable.Empty<ArticleTagResponse>();

	public IEnumerable<ArticleTagResponse> Interesting { get; set; } = Enumerable.Empty<ArticleTagResponse>();

	public IEnumerable<ArticleTagResponse> Hidden { get; set; } = Enumerable.Empty<ArticleTagResponse>();

	public void UpdateModel(User user)
	{
		throw new NotImplementedException();
	}
}