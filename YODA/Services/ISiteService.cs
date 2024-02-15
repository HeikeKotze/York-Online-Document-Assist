using YODA.Repos.Models;

namespace YODA.Services
{
    public interface ISiteService
    {
        List<Site> GetSites();
        List<Site> GetSitesForBusinessUnit(int buid);
        List<Site> GetSitesForInitiator(string user);

        string GetCorrespondingSiteName(int? id);

        int GetCorrespondingSiteID(string? siteName);
    }
}
