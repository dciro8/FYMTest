using UserManager.Domain.DTO;
using UserManager.Domain.Ports;

namespace UserManager.Domain.Services
{
    public class RoleService : IRoleRepository
    {
        private readonly IRoleRepository _iRoleRepository;
        public RoleService(IRoleRepository iRoleRepository)
        {
            _iRoleRepository = iRoleRepository;
        }

        public async Task<List<InfoRoleDto>> GetAllRole()
        {
            return await _iRoleRepository.GetAllRole();
        }

    }
}
