namespace Ordering.Application.Interfaces.MessageBroker;

public interface IMessageBrokerService
{
    Task Publish();
}