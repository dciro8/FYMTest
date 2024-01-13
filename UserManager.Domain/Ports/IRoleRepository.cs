using UserManager.Domain.DTO;

namespace UserManager.Domain.Ports
{
    public interface IRoleRepository
    {
        Task<List<InfoRoleDto>> GetAllRole();
    }

}
