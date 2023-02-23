using BeachDayFinder.BuildingBlocks.Messaging;

namespace BeachDayFinder.Prediction.Contracts;

public record WarmestDayPredictionRequested(string Id, string RequesterId, DateTimeOffset Timestamp) : IntegrationEvent(Id);