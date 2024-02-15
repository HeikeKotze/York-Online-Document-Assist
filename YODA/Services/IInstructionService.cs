using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IInstructionService
    {
        List<FkSignatoriesCapex> GetInstructions(int id);
    }
}
