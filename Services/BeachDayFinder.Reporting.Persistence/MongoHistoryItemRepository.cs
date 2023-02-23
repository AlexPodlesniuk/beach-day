using System.Collections.ObjectModel;
using BeachDayFinder.BuildingBlocks.Persistence.Mongo;
using BeachDayFinder.Reporting.Domain.HistoryItem;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BeachDayFinder.Reporting.Persistence;

public class MongoHistoryItemRepository : MongoDbRepository<HistoryItem>, IHistoryItemRepository
{
    public MongoHistoryItemRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase)
    {
    }


    public async Task<IReadOnlyCollection<HistoryItem>> GetHistoryRecordsByRequesterIdAsync(string requestRequesterId, int? requestCount, bool? requestNewFirst,
        CancellationToken cancellationToken)
    {
        var requesterItems = Aggregates.Where(x => x.RequesterId == requestRequesterId);

        if (requestCount.HasValue)
            requesterItems = requesterItems.Take(requestCount.Value);
        
        if (requestNewFirst.HasValue)
            requesterItems = requestNewFirst.Value ? requesterItems.OrderByDescending(x => x.Timestamp) : requesterItems.OrderBy(x => x.Timestamp);

        return new ReadOnlyCollection<HistoryItem>(requesterItems.ToArray());
    }
}