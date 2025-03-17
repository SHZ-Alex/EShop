using MassTransit;
using Microsoft.FeatureManagement;
using Ordering.Application.Dtos;
using Ordering.Application.Interfaces.MessageBroker;

namespace Ordering.Infrastructure.MessageBroker;

public class MessageBrokerService(IPublishEndpoint publishEndpoint,
    IFeatureManager featureManager) : IMessageBrokerService
{
    public async Task PublishOrderUpdatedEvent(OrderDto order, CancellationToken cancellationToken)
    {
        await publishEndpoint.Publish(order, cancellationToken);
    }

    public async Task PublishOrderCreatedEvent(OrderDto order, CancellationToken cancellationToken)
    {
        if (await featureManager.IsEnabledAsync("OrderUpdatedEvent"))
            await publishEndpoint.Publish(order, cancellationToken);
    }
    
    
}