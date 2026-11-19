using System.Security.Claims;
using EventPlanning;
using EventPlanning.Interfaces;
using EventPlanning.Repositories;
using EventPlanning.Services;
using EventPlanning.UserTest;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ICurrentUser, FakeCurrentUser>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<EventDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanViewAll", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddHealthChecks();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    if (app.Logger.IsEnabled(LogLevel.Information))
        app.Logger.LogInformation("Request starting: {Path}", context.Request.Path);

    await next();

    if (app.Logger.IsEnabled(LogLevel.Information))
        app.Logger.LogInformation("Request finished: {StatusCode}", context.Response.StatusCode);
});

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}")
    .RequireAuthorization();

//TODO: Add a dependency to check 
app.MapHealthChecks("/health");

app.MapControllers();

app.Run();