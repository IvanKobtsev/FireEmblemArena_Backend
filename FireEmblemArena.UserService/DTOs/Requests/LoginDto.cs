using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FireEmblemArena.UserService.DTOs.Requests;

public class LoginDto
{
    [EmailAddress] public string Email { get; set; } = string.Empty;
    [PasswordPropertyText] public string Password { get; set; } = string.Empty;
}