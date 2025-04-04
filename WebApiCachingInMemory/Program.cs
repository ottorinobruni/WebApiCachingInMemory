using Microsoft.Extensions.Caching.Hybrid;

var builder = WebApplication.CreateBuilder(args);

// Add HybridCache with Redis as distributed cache
builder.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(2),
            LocalCacheExpiration = TimeSpan.FromMinutes(1)
        };
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "my-redis";
});

builder.Services.AddScoped<IUserService, UserService>();  // Register UserService

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapGet("/users", async (IUserService userService) =>
{
    var users = await userService.GetUsers();
    return Results.Ok(users);
})
.WithName("GetUsers")
.WithOpenApi();

app.Run();
