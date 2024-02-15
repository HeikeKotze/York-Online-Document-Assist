using YODA.Repos.Models;
namespace YODA.Services
{
    public interface IFileHandlingService
    {
        List<FileTypes> GetAllFileTypes();
        void AddLinkedDocuments(List<LinkedDocuments> linkedDocuments);
        List<FileTypes> GetFileTypesPreDiscipline();
    }
}
