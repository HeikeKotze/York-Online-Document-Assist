using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IBusinessUnitService
    {
        List<BusinessUnit> GetBusinessUnitList();
        List<BusinessUnit> GetBusinessUnitForBusinessUnit(int buid);
        List<BusinessUnit> GetBusinessUnitForInitiator(string user);
        BusinessUnit GetBusinessUnitById(int id);
    }
}
