using Common.CQRS;
using Common.Exceptions;
using MediatR;
using Ordering.Application.Interfaces.Database;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Commands.Update;

public class UpdateOrderCommandHandler(IOrderDatabaseRepository orderDatabaseRepository)  : ICommandHandler<UpdateOrderCommand>
{
    public async Task<Unit> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await orderDatabaseRepository.GetByIdAsync(new OrderId(command.Order.Id), cancellationToken);

        if (order == null)
            throw new NotFoundException();
        
        UpdateOrderCommand.UpdateMap(order, command.Order);
        await orderDatabaseRepository.Update(order, cancellationToken);

        return Unit.Value;
    }
}