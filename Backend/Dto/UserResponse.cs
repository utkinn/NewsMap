using NewsMap.Model;

namespace NewsMap.Dto;

public sealed class UserResponse(User user)
{
	public string FirstName => user.FirstName;
	public string LastName => user.LastName;
	public string Email => user.Email!;
}