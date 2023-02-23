using BeachDayFinder.BuildingBlocks.Domain;

namespace BeachDayFinder.Reporting.Domain.HistoryItem;

public class HistoryItem : AggregateRoot
{
    public HistoryItem(string id, string requesterId, DateTimeOffset timestamp) : base(id)
    {
        RequesterId = requesterId;
        Timestamp = timestamp;
    }

    public string RequesterId { get; init; }
    public DateTimeOffset Timestamp { get; init; }
}