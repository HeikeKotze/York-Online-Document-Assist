using YODA.Repos.Models;

namespace YODA.Services
{
    public interface ICapexUserService
    {
        List<CapexUser> GetAll();
        CapexUser GetCapexUser(int id);
        List<CapexUser> GetCapexUserByBusinessUnit(int buid);
        List<CapexUser> GetCapexUserByInitiator(string user);
        void AddNewCapexUser(CapexUser user);

        void updateNewUser(int id);

        void lockUser(int id);
        int getUserIDByName(string userName);
    }
}
