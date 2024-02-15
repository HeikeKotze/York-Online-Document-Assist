using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IAccessService
    {
        UserAccess GetUserAccess(int id, int moduleid);
        void AddUserAccess(UserAccess userAccess);
        void setUserAccess(int id, int accesstype);

        List<UserAccess> GetAllUserAccess(int id);
    }
}
