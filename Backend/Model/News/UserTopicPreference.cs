using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewsMap.Model.News;

[PrimaryKey(nameof(UserId))]
public class UserTopicPreference
{
	public string UserId { get; private set; }
	public required User User { get; init; }

	public int TagId { get; private set; }
	public required ArticleTag Tag { get; init; }

	[Column(TypeName = "varchar(20)")]
	public required UserTopicPreferenceType Type { get; set; }
}

public enum UserTopicPreferenceType
{
	Important,
	Interesting,
	Hidden
}