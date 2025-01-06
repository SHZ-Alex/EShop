using Carter;
using Marten;
using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddMediatR(c =>
    c.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddMarten(c =>
{
    var ab = builder.Configuration.GetConnectionString("Database");
    c.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();


app.MapCarter();
app.Run();