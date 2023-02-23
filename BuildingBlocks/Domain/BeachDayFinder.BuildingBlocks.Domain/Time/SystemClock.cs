namespace BeachDayFinder.BuildingBlocks.Domain.Time;

public class SystemClock : IClock
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}