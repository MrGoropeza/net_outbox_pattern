using System.ComponentModel.DataAnnotations;

namespace Application.Users.SignUp;

public record SignUpRequest
{
    [Required, EmailAddress]
    public required string Email { get; init; }

    [Required, StringLength(50)]
    public required string UserName { get; init; }

    [Required, StringLength(15, MinimumLength = 8)]
    public required string Password { get; init; }
}
