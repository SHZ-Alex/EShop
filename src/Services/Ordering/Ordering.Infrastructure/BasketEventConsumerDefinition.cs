using Common.Messaging.Events;
using MassTransit;
using Ordering.Infrastructure.MessageBroker.Consumers;

namespace Ordering.Infrastructure;

public class BasketEventConsumerDefinition : ConsumerDefinition<BasketEventConsumer>
{
    public BasketEventConsumerDefinition()
    {
        EndpointName = "basket-checkout-queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<BasketEventConsumer> consumerConfigurator)
    {
        // Только если это RabbitMQ
        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            // Говорим, что хотим topic exchange и нужный routing key
            rmq.Bind<BasketCheckoutEvent>(x =>
            {
                x.ExchangeType = "topic";
            });
        }
    }
}