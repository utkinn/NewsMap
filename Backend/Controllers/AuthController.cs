using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NewsMap.Auth;

namespace NewsMap.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController : ControllerBase
{
	private readonly IOptions<JwtOptions> _jwtOptions;
	private readonly SignInManager<User> _signInManager;
	private readonly UserManager<User> _userManager;

	public AuthController(
		IOptions<JwtOptions> jwtOptions,
		SignInManager<User> signInManager,
		UserManager<User> userManager)
	{
		_jwtOptions = jwtOptions;
		_signInManager = signInManager;
		_userManager = userManager;
	}

	[HttpPost("login")]
	public async Task<IActionResult> GenerateToken(AuthRequest authRequest)
	{
		if (!await _userManager.Users.AnyAsync(u => u.UserName == "admin"))
		{
			await _userManager.CreateAsync(
				new User { UserName = "admin", FirstName = "", LastName = "" },
				"Admin12345!");
		}

		var signInResult =
			await _signInManager.PasswordSignInAsync(authRequest.UserName, authRequest.Password, false, false);
		if (!signInResult.Succeeded) return Unauthorized();

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new[]
			{
				new Claim("Id", Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Sub, authRequest.UserName),
				new Claim(JwtRegisteredClaimNames.Email, authRequest.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			}),
			Expires = DateTime.UtcNow + _jwtOptions.Value.Lifetime,
			Issuer = _jwtOptions.Value.Issuer,
			Audience = _jwtOptions.Value.Audience,
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_jwtOptions.Value.Key),
				SecurityAlgorithms.HmacSha512Signature)
		};
		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);

		return Content(tokenHandler.WriteToken(token));
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request)
	{
		var result = await _userManager.CreateAsync(request.ToUser(), request.Password);
		return result.Succeeded
			? Ok() // TODO: return token right away
			: BadRequest(result.Errors);
	}
}