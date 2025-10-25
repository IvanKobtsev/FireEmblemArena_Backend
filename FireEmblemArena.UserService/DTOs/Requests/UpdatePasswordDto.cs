using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FireEmblemArena.UserService.DTOs.Requests;

public class UpdatePasswordDto
{
    [Required] [PasswordPropertyText] public required string CurrentPassword { get; set; }
    [Required] [PasswordPropertyText] public required string NewPassword { get; set; }
}