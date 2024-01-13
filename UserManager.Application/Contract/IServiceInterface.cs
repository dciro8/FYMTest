using UserManager.Application.Models;
using UserManager.Domain.DTO;
using UserManager.Domain.Entities;

namespace UserManager.Application.Contract
{
    public interface IUserAppService
    {
        Task<RequestResultModel<UserDto>> Add(UserDto entity);
        Task<RequestResultModel<InfoUserDto>> GeUserForRoleEmail(string eMail, string password);
        Task<RequestResultModel<List<InfoUserDto>>> GetAllUser();
        RequestResultModel<InfoUserDto> GeTaskByEmail(string eMail, string password);

    }
}
