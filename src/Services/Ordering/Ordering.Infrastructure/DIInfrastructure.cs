using Common.Messaging.MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Interfaces.Database;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Interceptors;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Infrastructure;

public static class DiInfrastructure
{
    public static void AddInfrastructureDi(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext));

        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        builder.Services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        builder.Services.AddScoped<IOrderDatabaseRepository, OrderDatabaseRepository>();
        
        builder.Services.AddMessageBroker(builder.Configuration);
        
        builder.Services.AddDbContext<ApplicationDbContext>((services, opt) =>
        {
            opt.AddInterceptors(services.GetServices<ISaveChangesInterceptor>());
            opt.UseSqlServer(config);
        });
    }
}