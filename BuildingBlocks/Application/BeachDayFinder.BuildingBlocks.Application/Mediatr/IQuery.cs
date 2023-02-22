using BeachDayFinder.BuildingBlocks.Application.Result;
using MediatR;

namespace BeachDayFinder.BuildingBlocks.Application.Mediatr;

public interface IQuery<TResult> : IRequest<Result<TResult>>
{
}