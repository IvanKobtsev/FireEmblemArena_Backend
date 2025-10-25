using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FireEmblemArena.UserService.DTOs.Requests;

public class RegisterUserDto
{
    [EmailAddress] [Required] public string Email { get; set; } = string.Empty;

    [MaxLength(50)]
    [PasswordPropertyText]
    [Required]
    public string Password { get; set; } = string.Empty;

    [Phone]
    [MinLength(11)]
    [MaxLength(11)]
    public string? PhoneNumber { get; set; }
}