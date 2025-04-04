using Microsoft.Extensions.Caching.Hybrid;

public interface IUserService
{
    Task<List<User>> GetUsers();
}

public class UserService : IUserService
{
    private readonly HybridCache _hybridCache;
    private const string cacheKey = "users";

    public UserService(HybridCache hybridCache)
    {
        this._hybridCache = hybridCache;
    }
    
     public async Task<List<User>> GetUsers()
    {
        Console.WriteLine("GetUsers method called.");
        var users = await _hybridCache.GetOrCreateAsync(cacheKey, 
            async _ => {
                Console.WriteLine("Cache miss. Fetching data from the database.");
                return await GetValuesFromDbAsync();
            });

        Console.WriteLine("Data retrieved from the cache.");
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
