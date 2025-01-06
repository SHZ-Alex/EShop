using MediatR;

namespace Common.CQRS;

public interface ICommand<out T> : IRequest<T>;

public interface ICommand : IRequest<Unit>;