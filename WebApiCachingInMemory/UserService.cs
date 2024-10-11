using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

public interface IUserService
{
    Task<List<User>> GetUsers();
}

public class UserService : IUserService
{
    private readonly IDistributedCache _distributedCache;
    private const string cacheKey = "users";

    public UserService(IDistributedCache distributedCache)
    {
        this._distributedCache = distributedCache;
    }
    
    public async Task<List<User>> GetUsers()
    {
        var cachedUsers = await _distributedCache.GetStringAsync(cacheKey);

        if (cachedUsers != null)
        {
            return JsonSerializer.Deserialize<List<User>>(cachedUsers);
        }

        var users = await GetValuesFromDbAsync();

        var serializedUsers = JsonSerializer.Serialize(users);

        var cacheOptions = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

        await _distributedCache.SetStringAsync(cacheKey, serializedUsers, cacheOptions);

        return users;
    }

    private async Task<List<User>> GetValuesFromDbAsync()
    {
        List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Alice" },
            new User { Id = 2, Name = "Bob" },
            new User { Id = 3, Name = "Otto" },
        };

        // Simulating a long-running database query.
        await Task.Delay(2000); 
        return users;
    }
}
