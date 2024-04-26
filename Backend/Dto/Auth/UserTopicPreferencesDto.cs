using NewsMap.Dto.News;
using NewsMap.Model;
using NewsMap.Model.News;
using NewsMap.Repositories.News;

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

    public IEnumerable<ArticleTagResponse> Important { get; set; } = [];

    public IEnumerable<ArticleTagResponse> Interesting { get; set; } = [];

    public IEnumerable<ArticleTagResponse> Hidden { get; set; } = [];

    public async Task UpdateModelAsync(User user, ArticleTagRepository articleTagRepository)
    {
        user.TopicPreferences.AddRange(await GetUserTopicPreferencesToAddAsync(user, articleTagRepository));
        
        var existingPreferences = user.TopicPreferences.GroupBy(p => p.Type).ToDictionary(p => p.Key, p => p.ToArray());
        var newImportantTags = await Important.Where(t =>
                !existingPreferences[UserTopicPreferenceType.Important].Select(p => p.Tag.Name).Contains(t.Name))
            .Select(rs => rs.Name)
            .Apply(articleTagRepository.ListByNamesAndCreateMissingAsync);
        var importantTagsToRemove = existingPreferences[UserTopicPreferenceType.Important]
            .Where(p => !Important.Select(i => i.Name).Contains(p.Tag.Name))
            .Select(p => p.Tag.Name)
            .ToArray();
        user.TopicPreferences.AddRange(newImportantTags.Select(t => new UserTopicPreference
        {
            Tag = t,
            Type = UserTopicPreferenceType.Important,
            User = user
        }));
        user.TopicPreferences = user.TopicPreferences.Where(p => !importantTagsToRemove.Contains(p.Tag.Name)).ToList();
    }

    private async Task<IEnumerable<UserTopicPreference>> GetUserTopicPreferencesToAddAsync(
        User user,
        ArticleTagRepository articleTagRepository)
    {
        var toAdd = new List<UserTopicPreference>();
        var existingPreferences = user.TopicPreferences.GroupBy(p => p.Type).ToDictionary(p => p.Key, p => p.ToArray());

        await ProcessType(UserTopicPreferenceType.Important, Important);
        await ProcessType(UserTopicPreferenceType.Interesting, Interesting);
        await ProcessType(UserTopicPreferenceType.Hidden, Hidden);

        return toAdd;

        async Task ProcessType(UserTopicPreferenceType type, IEnumerable<ArticleTagResponse> dtos)
        {
            var newImportantTags = await dtos.Where(t =>
                    !existingPreferences[type].Select(p => p.Tag.Name).Contains(t.Name))
                .Select(rs => rs.Name)
                .Apply(articleTagRepository.ListByNamesAndCreateMissingAsync);

            toAdd.AddRange(newImportantTags.Select(t => new UserTopicPreference
            {
                Tag = t,
                Type = type,
                User = user
            }));
        }
    }
}