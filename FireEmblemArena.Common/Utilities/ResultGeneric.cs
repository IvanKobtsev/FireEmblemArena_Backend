using FireEmblemArena.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FireEmblemArena.Common.Utilities;

public class Result<T> : Result
{
    public T? Data { get; set; }

    public override IActionResult GetActionResult()
    {
        return Code == HttpCode.Ok ? new OkObjectResult(Data) : base.GetActionResult();
    }
}