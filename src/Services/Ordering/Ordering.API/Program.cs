using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebDI();
builder.AddApplicationDI();
builder.AddInfrastructureDi();

var app = builder.Build();


app.Run();