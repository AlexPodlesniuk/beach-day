using BeachDayFinder.BuildingBlocks.Application.Mediatr;

namespace BeachDayFinder.Reporting.Application.Queries.GetHistoryItemsByRequesterId;

public record GetHistoryItemsByRequesterId(string RequesterId, int? Count, bool? NewFirst) : IQuery<IReadOnlyCollection<HistoryItemResponse>>;
public record HistoryItemResponse(string RequesterId, DateTimeOffset ReceivedOn);