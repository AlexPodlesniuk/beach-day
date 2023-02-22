using BeachDayFinder.BuildingBlocks.Application.Result;
using MediatR;

namespace BeachDayFinder.BuildingBlocks.Application.Mediatr;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result.Result>
where TCommand : ICommand
{
    
}

public interface ICommandHandler<TCommand, TReponse> : IRequestHandler<TCommand, Result<TReponse>>
    where TCommand : ICommand<TReponse>
{
    
}