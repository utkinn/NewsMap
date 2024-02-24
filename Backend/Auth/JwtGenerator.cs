using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NewsMap.Model;

namespace NewsMap.Auth;

public sealed class JwtGenerator(IOptionsMonitor<JwtOptions> jwtOptions)
{
	public string Generate(User user)
	{
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new[]
			{
				new Claim("Id", Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Sub, user.Id),
				new Claim(JwtRegisteredClaimNames.Email, user.Email!),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			}),
			Expires = DateTime.UtcNow + jwtOptions.CurrentValue.Lifetime,
			Issuer = jwtOptions.CurrentValue.Issuer,
			Audience = jwtOptions.CurrentValue.Audience,
			SigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(jwtOptions.CurrentValue.Key),
				SecurityAlgorithms.HmacSha512Signature)
		};
		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}