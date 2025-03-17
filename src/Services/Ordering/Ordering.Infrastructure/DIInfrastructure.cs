using System.Reflection;
using Common.Messaging.MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Ordering.Application.Interfaces.Database;
using Ordering.Application.Interfaces.MessageBroker;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Interceptors;
using Ordering.Infrastructure.MessageBroker;
using Ordering.Infrastructure.MessageBroker.Consumers;
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
        
        builder.Services.AddMessageBroker(builder.Configuration, [typeof(BasketEventConsumer)]);
        builder.Services.AddScoped<IMessageBrokerService, MessageBrokerService>();
        builder.Services.AddFeatureManagement();
        
        builder.Services.AddDbContext<ApplicationDbContext>((services, opt) =>
        {
            opt.AddInterceptors(services.GetServices<ISaveChangesInterceptor>());
            opt.UseSqlServer(config);
        });
    }
}