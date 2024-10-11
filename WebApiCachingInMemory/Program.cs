
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();  // Register IMemoryCache
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

app.UseHttpsRedirection();

app.MapGet("/users", async (IUserService userService) =>
{
    var users = await userService.GetUsers();
    return Results.Ok(users);
})
.WithName("GetUsers")
.WithOpenApi();

app.Run();
