using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IAccessLinkingService
    {
        AccessLinking GetAccessLinkingForID (int id);
        int GetSpecificLinkingID(AccessLinking accessLinking);
        bool GetIfLinkExists(AccessLinking accessLinking);

        List<AccessLinking> GetSpecificAccessLinkings(AccessLinking accessLinking);
        AccessLinking GetAccessLinking(AccessLinking accessLinking);
        void AddAccessLinking(AccessLinking link);

    }
}
