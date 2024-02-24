using Microsoft.AspNetCore.Identity;
using NewsMap.Model;

namespace NewsMap.Auth;

public static class SignInManagerExtensions
{
	public static async Task<SignInResult> EmailPasswordSignInAsync(
		this SignInManager<User> signInManager,
		string email,
		string password,
		bool lockoutOnFailure)
	{
		var byEmail = await signInManager.UserManager.FindByEmailAsync(email);
		return byEmail == null
			? SignInResult.Failed
			: await signInManager.CheckPasswordSignInAsync(byEmail, password, lockoutOnFailure);
	}
}