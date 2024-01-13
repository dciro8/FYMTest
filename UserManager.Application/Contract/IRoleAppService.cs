using UserManager.Application.Models;
using UserManager.Domain.DTO;

namespace UserManager.Application.Contract
{
    public interface IRoleService
    {
        Task<RequestResultModel<List<InfoRoleDto>>> GetAllRole();
    }
}
