using Microsoft.AspNetCore.Mvc;
using BeachDayFinder.BuildingBlocks.Api.Abstractions;
using BeachDayFinder.Prediction.Application.Queries.FindNextWarmestDay;
using BeachDayFinder.Prediction.Domain;
using MediatR;

namespace BeachDayFinder.Prediction.Api.Controllers;

[Route("api/v1/prediction")]
public class BeachDayPredictorController : ApiController
{
    public BeachDayPredictorController(ISender sender) : base(sender)
    {
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PredictWarmestDay(
        [FromQuery(Name = "lat")] string lat,
        [FromQuery(Name = "lon")] string lon,
        [FromHeader(Name = "x-api-key")] string apiKey,
        CancellationToken cancellationToken)
    {
        if (apiKey is null)
            return BadRequest($"{nameof(apiKey)} is missing");
        
        var requestedLocation = new Location(new Coordinate(lat), new Coordinate(lon));
        
        var result = await Sender.Send(
            new FindNextWarmestDay(requestedLocation, apiKey), cancellationToken);

        if (result.IsFailure)
            return HandleFailure(result);

        return Ok(result.Value());
    }
}