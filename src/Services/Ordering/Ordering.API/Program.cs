using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebDi();
builder.AddApplicationDi();
builder.AddInfrastructureDi();

builder.Host
    .UseDefaultServiceProvider(options =>
    {
        options.ValidateScopes = true;
        options.ValidateOnBuild = true;
    });

var app = builder.Build();

app.AddWebApp();

await app.ApplyMigrations();

app.Run();