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
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _iUserService;
        public UsersController(IUserAppService iUserService)
        {
            _iUserService = iUserService;
        }
        [HttpPost]
        public async Task<RequestResultModel<UserDto>> Create(UserDto userDto)
            => await _iUserService.Add(userDto);
        
        [HttpGet]
        public async Task<RequestResultModel<InfoUserDto>> Get(string email, string password)
            => await _iUserService.GeUserForRoleEmail(email, password);
        
        [HttpGet]
        [Route(nameof(UsersController.GetAll))]
        public async Task<RequestResultModel<List<InfoUserDto>>> GetAll()
        => await _iUserService.GetAllUser();
    }
}
