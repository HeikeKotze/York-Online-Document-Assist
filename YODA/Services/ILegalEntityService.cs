using YODA.Repos.Models;

namespace YODA.Services
{
    public interface ILegalEntityService
    {
        List<LegalEntity> GetLegalEntities();
        List<LegalEntity> GetLegalEntitiesForBusinessUnit(int buid);
        List<LegalEntity> GetLegalEntitiesForIndividual(string user);
        string GetCorrespondingLegalEntity(int? id);
        LegalEntity GetLegalEntityById(int id);
    }
}
