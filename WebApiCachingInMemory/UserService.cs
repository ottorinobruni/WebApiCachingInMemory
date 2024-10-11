using Microsoft.Extensions.Caching.Memory;

public interface IUserService
{
    Task<List<User>> GetUsers();
}

public class UserService : IUserService
{
    private readonly IMemoryCache _memoryCache;
    private const string cacheKey = "users";

    public UserService(IMemoryCache memoryCache)
    {
        this._memoryCache = memoryCache;
    }
    
    public async Task<List<User>> GetUsers()
    {
        if (!_memoryCache.TryGetValue(cacheKey, out List<User> users))
        {
            users = await GetValuesFromDbAsync();

            _memoryCache.Set(cacheKey, users, 
                    new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60)));
        }

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
