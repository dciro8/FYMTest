using UserManager.Domain.DTO;
using UserManager.Domain.Entities;

namespace UserManager.Domain.Ports
{
    public interface IUserRepository
    {
        Task<User> Add(User entity);
        InfoUserDto GeTaskByEmail(string eMail, string password);
        Task<InfoUserDto> GetUserForRoleEmail(string eMail, string password);
        Task<List<InfoUserDto>> GetAllUser();
    }
}
