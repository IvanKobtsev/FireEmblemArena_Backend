using FireEmblemArena.Common.Enums;
using FireEmblemArena.Common.Utilities;
using FireEmblemArena.UserService.Services.Interfaces;
using StackExchange.Redis;

namespace FireEmblemArena.UserService.Services;

public class TokenStoreService(IConnectionMultiplexer redis) : ITokenStore
{
    private readonly IDatabase _db = redis.GetDatabase();

    public async Task StoreRefreshTokenAsync(string userId, string refreshToken, TimeSpan expiry)
    {
        await _db.HashSetAsync("refreshToUser", refreshToken, userId);
        await _db.HashSetAsync("userToRefresh", userId, refreshToken);
    }

    public async Task<string?> GetUserIdByRefreshToken(string refreshToken)
    {
        return await _db.HashGetAsync("refreshToUser", refreshToken);
    }

    public async Task<Result> RevokeRefreshTokenAsync(string userId)
    {
        var refreshToken = await _db.HashGetAsync("userToRefresh", userId);

        if (string.IsNullOrEmpty(refreshToken))
            return new Result
                { Code = HttpCode.BadRequest, Message = "User is already logged out" };

        await _db.HashDeleteAsync("refreshToUser", refreshToken);
        await _db.HashDeleteAsync("userToRefresh", userId);
        return new Result();
    }
}