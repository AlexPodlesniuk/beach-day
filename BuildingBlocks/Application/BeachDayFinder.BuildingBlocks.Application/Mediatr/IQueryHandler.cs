using BeachDayFinder.BuildingBlocks.Application.Result;
using MediatR;

namespace BeachDayFinder.BuildingBlocks.Application.Mediatr;

public interface IQueryHandler<in TQuery,TResponse> : IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{
    
}