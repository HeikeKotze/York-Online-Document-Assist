using YODA.Repos.Models;


namespace YODA.Services
{
    public interface IAssetCategoryService
    {
        List<AssetCategory> GetCategories();
    }
}
