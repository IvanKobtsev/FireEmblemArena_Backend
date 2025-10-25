using FireEmblemArena.Common.DTOs;
using FireEmblemArena.UserService.DTOs.Common;

namespace FireEmblemArena.UserService.DTOs.Responses;

public class ManagersPagedListDto
{
    public List<ProfileDto> Managers { get; set; }
    public PaginationDto Pagination { get; set; }
}