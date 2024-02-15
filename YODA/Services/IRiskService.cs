using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IRiskService
    {
        void saveRisks(List<Risk> risks);

        List<Risk> findRisksByCapex(int? id);

        void deleteRisksByCapex(int? id);
    }
}
