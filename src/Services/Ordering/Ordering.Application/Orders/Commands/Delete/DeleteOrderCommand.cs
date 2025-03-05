using Common.CQRS;

namespace Ordering.Application.Orders.Commands.Delete;

public record DeleteOrderCommand(Guid Id) : ICommand;