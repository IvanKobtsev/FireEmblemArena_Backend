using FireEmblemArena.Common.Utilities;

namespace FireEmblemArena.UserService.Services.Interfaces;

public interface ITokenStore
{
    Task StoreRefreshTokenAsync(string userId, string refreshToken, TimeSpan expiry);
    Task<string?> GetUserIdByRefreshToken(string refreshToken);
    Task<Result> RevokeRefreshTokenAsync(string userId);
}