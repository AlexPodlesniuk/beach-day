using BeachDayFinder.BuildingBlocks.Application.Mediatr;
using BeachDayFinder.BuildingBlocks.Persistence;
using MediatR;

namespace BeachDayFinder.BuildingBlocks.Application.Behaviors;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandAbstraction
{
    private readonly ITransaction _scopedTransaction;

    public TransactionBehavior(ITransaction scopedTransaction)
    {
        _scopedTransaction = scopedTransaction;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var response = await next();
            await _scopedTransaction.CommitTransactionAsync(cancellationToken);
            return response;
        }
        catch
        {
            await _scopedTransaction.AbortTransactionAsync(cancellationToken);
            throw;
        }
        
    }
}