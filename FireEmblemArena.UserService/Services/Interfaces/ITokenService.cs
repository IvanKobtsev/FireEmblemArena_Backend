using FireEmblemArena.UserService.DTOs.Common;

namespace FireEmblemArena.UserService.Services.Interfaces;

public interface ITokenService
{
    public string GenerateAccessToken(Guid userId, List<string> userRoles);

    public string GenerateRefreshToken();
    public Task<TokenDto> GenerateTokens(Guid userId, List<string> userRoles);
}