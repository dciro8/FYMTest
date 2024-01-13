using UserManager.Application.Contract;
using UserManager.Application.Models;
using UserManager.Domain.DTO;
using UserManager.Domain.Ports;

namespace UserManager.Application.Service
{
    public class RoleAppService : IRoleService
    {
        private readonly IRoleRepository _iRoleRepository;
        public RoleAppService(IRoleRepository iRoleRepository)
        {
            _iRoleRepository = iRoleRepository;
        }
        public async Task<RequestResultModel<List<InfoRoleDto>>> GetAllRole()
        {
            return new RequestResultModel<List<InfoRoleDto>>().CreateSuccessful(await _iRoleRepository.GetAllRole());
        }
    }
}
