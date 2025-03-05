using Common.CQRS;
using Common.Exceptions;
using MediatR;
using Ordering.Application.Interfaces.Database;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Commands.Delete;

public class DeleteOrderCommandHandler(IOrderDatabaseRepository orderDatabaseRepository) : ICommandHandler<DeleteOrderCommand>
{
    public async Task<Unit> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var result = await orderDatabaseRepository.Delete(new OrderId(command.Id), cancellationToken);

        if (!result)
            throw new NotFoundException();
        
        return Unit.Value;
    }
}