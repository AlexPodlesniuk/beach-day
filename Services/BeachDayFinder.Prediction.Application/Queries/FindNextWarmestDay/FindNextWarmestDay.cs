using BeachDayFinder.BuildingBlocks.Application.Mediatr;
using BeachDayFinder.Prediction.Domain;

namespace BeachDayFinder.Prediction.Application.Queries.FindNextWarmestDay;

public record FindNextWarmestDay(Location RequestedLocation, string RequesterId) : IQuery<NextWarmestDayResponse>;
public record NextWarmestDayResponse(string Day);