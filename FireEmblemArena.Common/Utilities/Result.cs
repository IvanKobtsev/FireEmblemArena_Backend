using FireEmblemArena.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireEmblemArena.Common.Utilities;

public class Result
{
    public HttpCode Code { get; set; } = HttpCode.Ok;
    public string? Message { get; set; }

    public bool IsFailed => (int)Code / 100 > 2;

    public virtual IActionResult GetActionResult()
    {
        return Code switch
        {
            HttpCode.Ok => new OkResult(),
            HttpCode.Created => new CreatedResult(),
            HttpCode.Accepted => new AcceptedResult(),
            HttpCode.NoContent => new NoContentResult(),
            HttpCode.BadRequest => new BadRequestObjectResult(new { Message }),
            HttpCode.Unauthorized => new UnauthorizedResult(),
            HttpCode.Forbidden => new ObjectResult(new { Message })
            {
                StatusCode = StatusCodes.Status403Forbidden
            },
            HttpCode.InternalServerError => new ObjectResult(new { Message })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            },
            HttpCode.NotFound => new NotFoundObjectResult(new { Message }),
            _ => throw new Exception("Unknown error code: " + Code)
        };
    }
}