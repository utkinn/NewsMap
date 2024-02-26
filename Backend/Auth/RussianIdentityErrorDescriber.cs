using Microsoft.AspNetCore.Identity;

namespace NewsMap.Auth;

public class RussianIdentityErrorDescriber : IdentityErrorDescriber
{
	public override IdentityError PasswordRequiresDigit() =>
		new()
		{
			Code = nameof(PasswordRequiresDigit),
			Description = "В пароле должна быть как минимум одна цифра."
		};

	public override IdentityError PasswordRequiresLower() =>
		new()
		{
			Code = nameof(PasswordRequiresLower),
			Description = "В пароле должна быть как минимум одна маленькая буква."
		};

	public override IdentityError PasswordRequiresUpper() =>
		new()
		{
			Code = nameof(PasswordRequiresUpper),
			Description = "В пароле должна быть как минимум одна большая буква."
		};

	public override IdentityError PasswordRequiresNonAlphanumeric() =>
		new()
		{
			Code = nameof(PasswordRequiresNonAlphanumeric),
			Description = "В пароле должен быть как минимум один знак пунктуации."
		};

	public override IdentityError PasswordTooShort(int length) =>
		new()
		{
			Code = nameof(PasswordTooShort),
			Description = $"Пароль должен быть длиннее {length} символов."
		};

	public override IdentityError InvalidEmail(string? email) =>
		new()
		{
			Code = nameof(InvalidEmail),
			Description = $"Email {email} не является верным."
		};
}
