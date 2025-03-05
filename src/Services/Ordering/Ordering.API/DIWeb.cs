using Common.ExceptionsHandler;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Ordering.API.Configs;
using Ordering.Infrastructure.Data;

namespace Ordering.API;

public static class DiWeb
{
    public static void AddWebDi(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseParameterTransformer()));
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks()
            .AddSqlServer(builder.Configuration.GetConnectionString(nameof(ApplicationDbContext))!);
        
        builder.Services.AddExceptionHandler<CustomExceptionHandler>();
    }

    public static void AddWebApp(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
        
        app.UseExceptionHandler(_ => { });
        app.UseHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.MapControllers();
    }
}