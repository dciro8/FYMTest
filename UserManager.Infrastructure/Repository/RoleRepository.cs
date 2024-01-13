using UserManager.Domain.DTO;
using UserManager.Domain.Ports;
using UserManager.Infrastructure.Context;

namespace UserManager.Infrastructure.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private UserDbContext _db;
        public RoleRepository(UserDbContext db)
        {
            this._db = db;
        }
        public async Task<List<InfoRoleDto>> GetAllRole()
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                List<InfoRoleDto> roleList = _db.Role.Select(x => x).ToList().Select(c => new InfoRoleDto()
                {
                    Description = c.Description,
                    IdentificaionCode = c.IdentificaionCode,
                }).ToList();

                return roleList;
            });
        }
    }
}
