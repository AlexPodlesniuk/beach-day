using BeachDayFinder.BuildingBlocks.Domain;
using MongoDB.Driver.Linq;

namespace BeachDayFinder.BuildingBlocks.Persistence.Mongo;

public interface IMongoRepository<TEntity> : IRepository<TEntity>
where TEntity : AggregateRoot
{
    IMongoQueryable<TEntity> Aggregates { get; }
}