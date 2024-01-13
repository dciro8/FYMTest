using UserManager.Application.Models;
using UserManager.Domain.Entities;

namespace UserManager.Application.Mapper
{
    public class UserMapper
    {
        public UserMapper() { }
        public static UserDto UserDTO_User(User user ) {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                Password = user.Password,
                LastName = user.LastName,
                DocumentType = user.DocumentType,
                DocumentNumber = user.DocumentNumber,
                Role = user.Role,
                State = user.State,
            };
        }

        public static User User_UserDTO(UserDto userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                Password = userDTO.Password,
                LastName = userDTO.LastName,
                DocumentType = userDTO.DocumentType,
                DocumentNumber = userDTO.DocumentNumber,
                Role = userDTO.Role,
                State = userDTO.State,
            };
        }
    }
}
