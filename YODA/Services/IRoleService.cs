using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IRoleService
    {
        List<Role> GetRoles();

        string GetRoleById(int id);
    }
}
