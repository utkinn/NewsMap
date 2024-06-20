using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsMap.Dto.Auth;
using NewsMap.Model;

namespace NewsMap.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProfileController(UserManager<User> userManager) : ControllerBase
{
	[HttpGet]
	[Authorize]
	public async Task<IActionResult> GetUser()
	{
		var user = await userManager.GetUserAsync(User);
		if (user == null)
			return Unauthorized();

		return Ok(await UserDto.FromModelAsync(user, userManager));
	}

	[HttpPut]
	public async Task<IActionResult> UpdateUser(UserDto request)
	{
		var user = await userManager.GetUserAsync(User);
		if (user == null)
			return Unauthorized();

		request.UpdateModel(user);
		await userManager.UpdateAsync(user);
		return Ok(await UserDto.FromModelAsync(user, userManager));
	}
	
	[HttpPost("avatar")]
	[Authorize]
	public async Task<IActionResult> ChangeAvatar()
	{
		throw new NotImplementedException();
	}
}