using BeachDayFinder.BuildingBlocks.Application.Mediatr;
using BeachDayFinder.BuildingBlocks.Application.Result;
using BeachDayFinder.BuildingBlocks.Domain.Time;
using BeachDayFinder.BuildingBlocks.Messaging;
using BeachDayFinder.Prediction.Contracts;
using BeachDayFinder.Prediction.Domain;

namespace BeachDayFinder.Prediction.Application.Queries.FindNextWarmestDay;

internal class FindNextWarmestDayHandler : IQueryHandler<FindNextWarmestDay, NextWarmestDayResponse>
{
    private readonly IWeatherForecastProvider _weatherForecastProvider;
    private readonly IIntegrationEventPublisher _publisher;
    private readonly IClock _clock;

    public FindNextWarmestDayHandler(IWeatherForecastProvider weatherForecastProvider, IIntegrationEventPublisher publisher, IClock clock)
    {
        _weatherForecastProvider = weatherForecastProvider;
        _publisher = publisher;
        _clock = clock;
    }

    public async Task<Result<NextWarmestDayResponse>> Handle(FindNextWarmestDay request, CancellationToken cancellationToken)
    {
        await _publisher.PublishAsync(new WarmestDayPredictionRequested(
            Guid.NewGuid().ToString(),
            request.RequesterId,
            _clock.Now
        ), cancellationToken);

        var forecastResult = await _weatherForecastProvider.PredictWarmestDayAsync(
            request.RequestedLocation,
            cancellationToken);
        
        return Result.Ok(new NextWarmestDayResponse(forecastResult.PerfectBeachDay()));
    }
}