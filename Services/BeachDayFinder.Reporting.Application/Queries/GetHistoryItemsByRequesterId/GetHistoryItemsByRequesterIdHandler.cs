using BeachDayFinder.BuildingBlocks.Application.Mediatr;
using BeachDayFinder.BuildingBlocks.Application.Result;
using BeachDayFinder.Reporting.Domain.HistoryItem;

namespace BeachDayFinder.Reporting.Application.Queries.GetHistoryItemsByRequesterId;

internal class GetHistoryItemsByRequesterIdHandler : IQueryHandler<GetHistoryItemsByRequesterId, IReadOnlyCollection<HistoryItemResponse>>
{
    private readonly IHistoryItemRepository _historyItemRepository;

    public GetHistoryItemsByRequesterIdHandler(IHistoryItemRepository historyItemRepository)
    {
        _historyItemRepository = historyItemRepository;
    }

    public async Task<Result<IReadOnlyCollection<HistoryItemResponse>>> Handle(GetHistoryItemsByRequesterId request, CancellationToken cancellationToken)
    {
        var items = await _historyItemRepository.GetHistoryRecordsByRequesterIdAsync(request.RequesterId, request.Count, request.NewFirst, cancellationToken);
        var responseItems = items.Select(x => new HistoryItemResponse(x.RequesterId, x.Timestamp));
        return Result.Ok<IReadOnlyCollection<HistoryItemResponse>>(responseItems.ToArray());
    }
}