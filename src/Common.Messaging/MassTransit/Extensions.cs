using System.Reflection;
using Common.Messaging.Events;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Messaging.MassTransit;

public static class Extensions
{
    public static void AddMessageBroker(this IServiceCollection services, IConfiguration configuration, Type[] consumers)
    {
        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            foreach (var consumer in consumers)
                config.AddConsumer(consumer);

            config.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                {
                    host.Username(configuration["MessageBroker:Username"]!);
                    host.Password(configuration["MessageBroker:Password"]!);
                });
                configurator.ConfigureEndpoints(context);
                
                configurator.ReceiveEndpoint("basket-checkout-queue", e =>
                {
                    e.Bind<BasketCheckoutEvent>(x =>
                    {
                        x.ExchangeType = "topic";
                    });
                });
            });
        });
    }
}