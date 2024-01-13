using UserManager.Domain.DTO;
using UserManager.Domain.Entities;
using UserManager.Domain.Ports;

namespace UserManager.Domain.Services
{
    public class UserService : IUserRepository
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Add(User entity)
        {
            var result = await _userRepository.Add(entity);
            return result;
        }
        public async Task<List<InfoUserDto>> GetAllUser()
        {
            return await _userRepository.GetAllUser();
        }
        public async Task<InfoUserDto> GetUserForRoleEmail(string eMail, string password)
        {
            return await _userRepository.GetUserForRoleEmail(eMail, password);
        }
       public InfoUserDto GeTaskByEmail(string eMail, string password)
        {
            return _userRepository.GeTaskByEmail(eMail, password);
        }
      }
    }

