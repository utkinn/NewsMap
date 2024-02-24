using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NewsMap.Model;

public class UserValidator : UserValidator<User>
{
	public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
	{
		ArgumentNullException.ThrowIfNull(manager, nameof(manager));
		ArgumentNullException.ThrowIfNull(user, nameof(user));
		List<IdentityError> errors = [];
		errors = await ValidateEmail(manager, user, errors);
		return errors.Count <= 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
	}

	private async Task<List<IdentityError>> ValidateEmail(
		UserManager<User> manager,
		User user,
		List<IdentityError> errors)
	{
		var email = await manager.GetEmailAsync(user);
		if (string.IsNullOrWhiteSpace(email))
		{
			errors.Add(Describer.InvalidEmail(email));
			return errors;
		}

		if (!new EmailAddressAttribute().IsValid(email))
		{
			errors.Add(Describer.InvalidEmail(email));
			return errors;
		}

		var existingUserWithEmail = await manager.FindByEmailAsync(email);
		if (existingUserWithEmail == null)
			return errors;
		
		var existingUserId = await manager.GetUserIdAsync(existingUserWithEmail);
		if (existingUserId == await manager.GetUserIdAsync(user))
			errors.Add(Describer.DuplicateEmail(email));

		return errors;
	}
}