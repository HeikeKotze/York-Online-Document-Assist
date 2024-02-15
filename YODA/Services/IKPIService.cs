using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IKPIService
    {
        List<Kpi> GetAllKPIs();

        void saveKPI(List<FkKpicapex> kpi);

        List<FkKpicapex> findKPIsByCapex(int? id);

        void deleteKPIsByCapex(int? id);

        string getKPItype(int? id);
    }
}
