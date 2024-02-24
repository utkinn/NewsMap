using Microsoft.AspNetCore.Identity;

namespace NewsMap.Auth;

public static class SignInManagerExtensions
{
	public static async Task<SignInResult> EmailPasswordSignInAsync(
		this SignInManager<User> signInManager,
		string email,
		string password,
		bool isPersistent,
		bool lockoutOnFailure)
	{
		var byEmail = await signInManager.UserManager.FindByEmailAsync(email);
		return byEmail == null
			? SignInResult.Failed
			: await signInManager.PasswordSignInAsync(byEmail, password, isPersistent, lockoutOnFailure);
	}
}