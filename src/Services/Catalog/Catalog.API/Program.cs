using Carter;
using Catalog.API.Data.InitialData;
using Common.Behaviors;
using Common.ExceptionsHandler;
using FluentValidation;
using Marten;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssembly(typeof(Program).Assembly);
    c.AddOpenBehavior(typeof(ValidationBehavior<,>));
    c.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddMarten(c =>
{ 
    c.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions().InitializeWith<ProductInitialData>();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(opt => {});

app.Run();