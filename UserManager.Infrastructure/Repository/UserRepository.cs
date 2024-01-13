using UserManager.Domain.DTO;
using UserManager.Domain.Entities;
using UserManager.Domain.Ports;
using UserManager.Infrastructure.Context;

namespace UserManager.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserDbContext _db;
        public UserRepository(UserDbContext db)
        {
            this._db = db;
        }
        public async Task<User> Add(User entity)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                _db.Add(entity);
                saveChanges();
                return entity;
            });
        }

        public int Delete(Guid id)
        {
            var register = _db.User.Where(w => w.Id.Equals(id)).FirstOrDefault();

            if (register != null)
            {
                _db.User.Remove(register);
                saveChanges();
                return 1;
            }
            else return 0;
        }     

        public List<User> Get()
        {
            return _db.User.ToList();
        }

        public async Task<List<InfoUserDto>> GetAllUser()
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                List<InfoUserDto> userList = _db.User.Select(x => x).ToList().Select(c => new InfoUserDto()
                {
                    Email = c.Email,
                    DocumentNumber = c.DocumentNumber,
                    FirstName = c.FirstName,
                    DocumentType = c.DocumentType,
                    State = c.State,
                    LastName = c.LastName,
                    Id = c.Id,
                    CodeRole = c.Role.ToString(),
                }).ToList();

                foreach (InfoUserDto item in userList)
                {
                    var vlue = _db.Role?.Where(x => x.Id.Equals(Guid.Parse(item.CodeRole)))?.FirstOrDefault().Description;
                    item.CodeRole = vlue;
                }
                return userList;
            });
        }

        public InfoUserDto GeTaskByEmail(string eMail, string password)
        {
            return _db.User.Where(x => x.Email.Equals(eMail) && x.Password.Equals(password)).Select(c => new InfoUserDto()
            {
                Email = c.Email,
                DocumentNumber = c.DocumentNumber,
                FirstName = c.FirstName,
                DocumentType = c.DocumentType,
                State = c.State,
                LastName = c.LastName,
                Id = c.Id,
                CodeRole = c.Role.ToString(),
            }).FirstOrDefault();

        }
        public async Task<InfoUserDto> GetUserForRoleEmail(string eMail, string password)
        {   
            return await System.Threading.Tasks.Task.Run(() =>
            {
                User user = _db.User?.Where(x => x.Email.Equals(eMail) && x.Password.Equals(password))?.FirstOrDefault();

                if (user != null)
                {
                    Role rol = _db.Role?.Where(x => x.Id.Equals(user.Role))?.FirstOrDefault();

                    return new InfoUserDto
                    {
                        Id = user.Id,
                        CodeRole = rol.IdentificaionCode,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DocumentNumber = user.DocumentNumber,
                        DocumentType = user.DocumentType,
                        State = user.State
                    };
                }
                else { return null; }
                
            });
        }
        public void saveChanges()
        {
            _db.SaveChanges();
        }
    }
}
