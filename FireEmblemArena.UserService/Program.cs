using System.Text.Json.Serialization;
using FireEmblemArena.Common.Extensions;
using FireEmblemArena.UserService.Data;
using FireEmblemArena.UserService.Models;
using FireEmblemArena.UserService.Services;
using FireEmblemArena.UserService.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;
using StackExchange.Redis;
using UniGate.Common.Logging;

SerilogLogger.ConfigureLogging();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllersWithJsonSerializers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthSwaggerGen(builder.Configuration);

builder.Services.AddSingleton<IConnectionMultiplexer>(_ =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection") ??
                                  throw new InvalidOperationException(
                                      "RedisConnection:Connection string is missing in configuration.")));

builder.Services.AddScoped<ITokenStore, TokenStoreService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
// builder.Services.AddScoped<IApplicantService, ApplicantService>();
// builder.Services.AddScoped<IManagerService, ManagerService>();
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
// builder.Services.AddScoped<IRabbitMqConnection, RabbitMqConnection>();
// builder.Services.AddScoped<IPublishingService, PublishingService>();
// builder.Services.AddSingleton<IMessagePublisher, MessagePublisher>();

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    })
    .AddNewtonsoftJson(x =>
    {
        x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        x.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthenticationAndAuthorization(builder.Configuration);

var app = builder.Build();

app.UseRequestLoggingMiddleware();
app.UseResponseLoggingMiddleware();
app.UseExceptionHandlingMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();