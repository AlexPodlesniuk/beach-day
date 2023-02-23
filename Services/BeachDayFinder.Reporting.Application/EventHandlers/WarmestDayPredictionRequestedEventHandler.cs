using BeachDayFinder.Prediction.Contracts;
using BeachDayFinder.Reporting.Domain.HistoryItem;
using NServiceBus;

namespace BeachDayFinder.Reporting.Application.EventHandlers;

internal class WarmestDayPredictionRequestedEventHandler : IHandleMessages<WarmestDayPredictionRequested>
{
    private readonly IHistoryItemRepository _historyItemRepository;

    public WarmestDayPredictionRequestedEventHandler(IHistoryItemRepository historyItemRepository)
    {
        _historyItemRepository = historyItemRepository;
    }

    public async Task Handle(WarmestDayPredictionRequested message, IMessageHandlerContext context)
    {
        var itemId = await _historyItemRepository.AllocateIdentifierAsync(context.CancellationToken);
        await _historyItemRepository.SaveAsync(new HistoryItem(itemId, message.RequesterId, message.Timestamp),
            context.CancellationToken);
    }
}