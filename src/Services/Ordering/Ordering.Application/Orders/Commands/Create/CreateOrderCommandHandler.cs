using Common.CQRS;
using Ordering.Application.Interfaces.Database;

namespace Ordering.Application.Orders.Commands.Create;

public class CreateOrderCommandHandler(IOrderDatabaseRepository orderDatabaseRepository) 
    : ICommandHandler<CreateOrderCommand, CreateOrderCommandResponse>
{
    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var entity = CreateOrderCommand.Map(command.Order);
        
        await orderDatabaseRepository.Create(entity, cancellationToken);

        return new CreateOrderCommandResponse(entity.Id.Id);
    }
}