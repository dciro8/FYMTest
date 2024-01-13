using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManager.Application.Contract;
using UserManager.Application.Models;
using UserManager.Domain.DTO;

namespace UserManager.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _iRoleService;
        public RolesController(IRoleService iRoleService)
        {
            _iRoleService = iRoleService;
        }

        [HttpGet]
        [Route(nameof(RolesController.GetRoleAll))]
        public async Task<RequestResultModel<List<InfoRoleDto>>> GetRoleAll()
        => await _iRoleService.GetAllRole();
    }
}
