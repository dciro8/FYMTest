using UserManager.Application.Common;
using UserManager.Application.Contract;
using UserManager.Application.Mapper;
using UserManager.Application.Models;
using UserManager.Application.Validations;
using UserManager.Domain.DTO;
using UserManager.Domain.Entities;
using UserManager.Domain.Ports;

namespace UserManager.Application.Service
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _iUserRepository;
        public UserAppService(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }
        public async Task<RequestResultModel<UserDto>> Add(UserDto userDTO)
        {
            RequestResultModel<UserDto> response = new RequestResultModel<UserDto>();
            try
            {
                UserValidation validateFields = new();
                var validatorResult = validateFields.Validate(userDTO);

                if (validatorResult.Errors.Any())
                {
                    response.CreateError(validatorResult.Errors.Select(s => s.ErrorMessage).Aggregate((a, b) => $"{a}, {b}"));
                    return response;
                }

                userDTO.Password = encryptCode.EncodePassword((userDTO.Password));
                User userEntity = UserMapper.User_UserDTO(userDTO);

                var result= await _iUserRepository.Add(userEntity);

                UserDto value = UserMapper.UserDTO_User(result);
                response.CreateSuccessful(value);

                return response;
            }
            catch (Exception e)
            {
                return response.CreateError($"{e.InnerException.Message} , Message {e.Message}");
            }
        }

        public async Task<RequestResultModel<InfoUserDto>> GeUserForRoleEmail(string eMail, string password)
        {
            try
            {
                InfoUserDto infoUserDTO = await _iUserRepository.GetUserForRoleEmail (eMail, encryptCode.EncodePassword(password));
                return new RequestResultModel<InfoUserDto>().CreateSuccessful(infoUserDTO);
            }
            catch (Exception e)
            {
                return new RequestResultModel<InfoUserDto>().CreateError($"{e.InnerException.Message} , Message {e.Message}");
            }
        }

        public async Task<RequestResultModel<List<InfoUserDto>>> GetAllUser()
        {
            try
            { 
                List<InfoUserDto> infoUserDtos= await _iUserRepository.GetAllUser();
                return  new RequestResultModel<List<InfoUserDto>>().CreateSuccessful(infoUserDtos);
            }
            catch (Exception e)
            {
                return new RequestResultModel<List<InfoUserDto>>().CreateError($"{e.InnerException.Message} , Message {e.Message}");
            }
        }

        public RequestResultModel<InfoUserDto> GeTaskByEmail(string eMail, string password)
        {
            try
            { 
                InfoUserDto infoUserDtos = _iUserRepository.GeTaskByEmail(eMail, encryptCode.EncodePassword(( password)));
                return new RequestResultModel<InfoUserDto>().CreateSuccessful(infoUserDtos);
            }
            catch (Exception e)
            {
                return new RequestResultModel<InfoUserDto>().CreateError($"{e.InnerException.Message} , Message {e.Message}");
            }
        }
    }
}
