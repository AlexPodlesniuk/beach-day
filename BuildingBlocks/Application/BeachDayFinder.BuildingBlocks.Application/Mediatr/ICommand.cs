using BeachDayFinder.BuildingBlocks.Application.Result;
using MediatR;

namespace BeachDayFinder.BuildingBlocks.Application.Mediatr;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, ICommandAbstraction
{
}

public interface ICommand : IRequest<Result.Result>, ICommandAbstraction
{
}

public interface ICommandAbstraction
{
}