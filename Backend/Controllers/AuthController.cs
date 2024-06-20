using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsMap.Auth;
using NewsMap.Model;

namespace NewsMap.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(
    SignInManager<User> signInManager,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    JwtGenerator jwtGenerator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> GenerateToken(AuthRequest authRequest)
    {
        if (!await userManager.Users.AnyAsync(u => u.Email == "admin@somaps.ru"))
        {
            var admin = new User { Email = "admin@somaps.ru", FirstName = "Иван", LastName = "" };
            await userManager.CreateAsync(admin, "Admin12345!");
            await roleManager.CreateAsync(new IdentityRole(Roles.Administrator));
            await userManager.AddToRoleAsync(admin, Roles.Administrator);
        }

        var signInResult = await signInManager.EmailPasswordSignInAsync(
            authRequest.Email,
            authRequest.Password,
            lockoutOnFailure: false);
        if (!signInResult.Succeeded)
            return Unauthorized();

        var user = await userManager.FindByEmailAsync(authRequest.Email)!;
        return new JsonResult(new { token = await jwtGenerator.GenerateAsync(user), userName = user.FirstName });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (await userManager.FindByEmailAsync(request.Email) != null)
            return Problem(
                detail: "Учетная запись с этой электронной почтой уже существует. "
                        + "Если это ваш адрес, попробуйте восстановить пароль.",
                statusCode: 400,
                title: "Адрес электронной почты занят");

        var user = request.ToUser();
        var result = await userManager.CreateAsync(user, request.Password);
        return result.Succeeded
            ? new JsonResult(new { token = await jwtGenerator.GenerateAsync(user) })
            : ConvertIdentityResultErrorsToProblemDetails(result);
    }

    [HttpPost("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        var user = await GetIdentityUserAsync();
        if (user == null)
            return Unauthorized();

        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        return result.Succeeded ? Ok() : ConvertIdentityResultErrorsToProblemDetails(result);
    }

    [HttpPost("delete-account")]
    [Authorize]
    public async Task<IActionResult> DeleteAccount(DeleteAccountRequest request)
    {
        var user = await GetIdentityUserAsync();
        if (user == null)
            return Unauthorized();

        if (!await userManager.CheckPasswordAsync(user, request.Password))
            return Problem(statusCode: 400, title: "Неверный пароль", detail: "Вы ввели неверный пароль.");

        await userManager.DeleteAsync(user);
        return Ok();
    }

    private ObjectResult ConvertIdentityResultErrorsToProblemDetails(IdentityResult result)
    {
        return Problem(
            statusCode: 400,
            title: "Неверные данные",
            detail: string.Join('\n', result.Errors.Select(e => e.Description)));
    }

    private async Task<User?> GetIdentityUserAsync() => await userManager.GetUserAsync(User);
}