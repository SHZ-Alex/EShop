using Carter;
using Catalog.API.Data.InitialData;
using Common.Behaviors;
using Common.ExceptionsHandler;
using FluentValidation;
using HealthChecks.UI.Client;
using Marten;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssembly(typeof(Program).Assembly);
    c.AddOpenBehavior(typeof(ValidationBehavior<,>));
    c.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var dbConnection = builder.Configuration.GetConnectionString("Database")!;

builder.Services.AddMarten(c =>
{ 
    c.Connection(dbConnection);
}).UseLightweightSessions().InitializeWith<ProductInitialData>();

builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnection);

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

app.MapCarter();    
app.UseExceptionHandler(opt => {});

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();