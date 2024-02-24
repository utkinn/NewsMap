using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsMap.Auth;
using NewsMap.Dto;
using NewsMap.Model;

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
		if (!await userManager.Users.AnyAsync(u => u.Email == "admin@somaps.ru"))
		{
			await userManager.CreateAsync(
				new User { Email = "admin@somaps.ru", FirstName = "", LastName = "" },
				"Admin12345!");
		}

		var signInResult = await signInManager.EmailPasswordSignInAsync(
			authRequest.Email,
			authRequest.Password,
			lockoutOnFailure: false);
		if (!signInResult.Succeeded)
			return Unauthorized();

		var user = await userManager.FindByEmailAsync(authRequest.Email);
		return Content(jwtGenerator.Generate(user!));
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request)
	{
		var user = request.ToUser();
		var result = await userManager.CreateAsync(user, request.Password);
		return result.Succeeded
			? Content(jwtGenerator.Generate(user))
			: BadRequest(result.Errors);
	}

	[HttpGet("user")]
	[Authorize]
	public async Task<UserResponse> GetUser() => new((await userManager.GetUserAsync(User))!);
}