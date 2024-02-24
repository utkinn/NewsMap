using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsMap.Auth;

namespace NewsMap.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(
	SignInManager<User> signInManager,
	UserManager<User> userManager,
	JwtGenerator jwtGenerator) : ControllerBase
{
	[HttpPost("login")]
	public async Task<IActionResult> GenerateToken(AuthRequest authRequest)
	{
		if (!await userManager.Users.AnyAsync(u => u.UserName == "admin"))
		{
			await userManager.CreateAsync(
				new User { UserName = "admin", FirstName = "", LastName = "" },
				"Admin12345!");
		}

		var signInResult = await signInManager.EmailPasswordSignInAsync(
			authRequest.Email,
			authRequest.Password,
			isPersistent: false,
			lockoutOnFailure: false);
		if (!signInResult.Succeeded)
			return Unauthorized();

		return Content(jwtGenerator.Generate(authRequest.Email));
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request)
	{
		var result = await userManager.CreateAsync(request.ToUser(), request.Password);
		return result.Succeeded
			? Content(jwtGenerator.Generate(request.Email))
			: BadRequest(result.Errors);
	}
}