using FireEmblemArena.Common.DTOs;
using FireEmblemArena.Common.Enums;

namespace FireEmblemArena.Common.Utilities;

public class PaginatedList<T>
{
    public required List<T> Items { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int PagesCount => int.Max(TotalCount % PageSize == 0 ? TotalCount / PageSize : TotalCount / PageSize + 1, 1);

    public Result<PaginatedListDto<TF>> ToResultOfPaginatedListDto<TF>(Func<List<T>, List<TF>> toNeededList)
    {
        if (PageIndex > PagesCount)
            return new Result<PaginatedListDto<TF>>
            {
                Code = HttpCode.BadRequest,
                Message = "Page index is out of range"
            };

        return new Result<PaginatedListDto<TF>>
        {
            Data = new PaginatedListDto<TF>
            {
                Pagination = new PaginationDto
                {
                    Count = PagesCount,
                    Current = PageIndex,
                    Size = PageSize
                },
                Items = toNeededList(Items)
            }
        };
    }
}