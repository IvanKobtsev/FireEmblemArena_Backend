using FireEmblemArena.UserService.DTOs.Common;
using FireEmblemArena.UserService.DTOs.Requests;
using FireEmblemArena.UserService.Models;

namespace FireEmblemArena.UserService.Mappers;

public static class UserMapper
{
    public static ProfileDto ToDto(this User user, List<string> roles)
    {
        return new ProfileDto
        {
            Id = user.Id,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber,
            Roles = roles
        };
    }

    public static User ToUser(this RegisterUserDto userDto)
    {
        return new User
        {
            UserName = userDto.Email,
            Email = userDto.Email,
            PhoneNumber = userDto.PhoneNumber ?? string.Empty
        };
    }
}