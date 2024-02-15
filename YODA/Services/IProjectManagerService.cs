using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IProjectManagerService
    {
        List<CapexUser> GetUsers();
    }
}
