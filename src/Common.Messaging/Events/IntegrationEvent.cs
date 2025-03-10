namespace Common.Messaging.Events;

public class IntegrationEvent
{
    public required Guid Id { get; set; }
    public required DateTimeOffset Date { get; set; }
    public required string EventType { get; set; }
}