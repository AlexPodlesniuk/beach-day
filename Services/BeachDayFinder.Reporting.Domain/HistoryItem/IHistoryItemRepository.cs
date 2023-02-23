using BeachDayFinder.BuildingBlocks.Domain;

namespace BeachDayFinder.Reporting.Domain.HistoryItem;

public interface IHistoryItemRepository : IRepository<HistoryItem>
{
    Task<IReadOnlyCollection<HistoryItem>> GetHistoryRecordsByRequesterIdAsync(string requestRequesterId, int? requestCount, bool? requestNewFirst, CancellationToken cancellationToken);
}