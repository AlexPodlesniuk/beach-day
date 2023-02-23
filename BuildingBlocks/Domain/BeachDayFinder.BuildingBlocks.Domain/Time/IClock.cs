namespace BeachDayFinder.BuildingBlocks.Domain.Time;

public interface IClock
{
    DateTimeOffset Now { get; }
}