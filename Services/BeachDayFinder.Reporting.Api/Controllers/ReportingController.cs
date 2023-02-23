using BeachDayFinder.BuildingBlocks.Api.Abstractions;
using BeachDayFinder.Reporting.Application.Queries.GetHistoryItemsByRequesterId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeachDayFinder.Reporting.Api.Controllers;

[Route("api/v1/reporting")]
public class ReportingController : ApiController
{
    public ReportingController(ISender sender) : base(sender)
    {
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRequesterHistory(
        [FromQuery(Name = "requesterId")]string requesterId,
        [FromQuery(Name = "count")]int? count,
        [FromQuery(Name = "newFirst")]bool? newFirst)
    {
        var requesterHistoryResult = await Sender.Send(new GetHistoryItemsByRequesterId(requesterId, count, newFirst));

        if (requesterHistoryResult.IsFailure)
            return HandleFailure(requesterHistoryResult);

        return Ok(requesterHistoryResult.Value());
    }
}