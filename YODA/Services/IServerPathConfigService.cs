using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IServerPathConfigService
    {
        ServerPathConfig GetServerPathConfig(int id);
    }
}
