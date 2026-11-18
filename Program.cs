using System.Security.Claims;
using EventPlanning;
using EventPlanning.Interfaces;
using EventPlanning.Repositories;
using EventPlanning.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();


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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Request starting: {context.Request.Path}");
    await next(); // pass control to the next middleware
    Console.WriteLine($"Request finished: {context.Response.StatusCode}");
});
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}")
    .RequireAuthorization();

app.MapControllers();

app.Run();