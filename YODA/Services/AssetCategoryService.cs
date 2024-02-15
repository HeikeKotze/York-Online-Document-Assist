

using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class AssetCategoryService : IAssetCategoryService
    {
        private readonly dbfirstcontext _dbc;
        public AssetCategoryService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public List<AssetCategory> GetCategories()
        {
            try
            {
                return _dbc.AssetCategories
                    .Where(x=>x.RecStatus == 1)
                    .Select(x => new AssetCategory
                    {
                        AssetCategoryId = x.AssetCategoryId,
                        AssetCategoryName = x.AssetCategoryName,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                // Get the stack trace as a string
                string stackTrace = new StackTrace(ex).ToString();

                // Log or display the stack trace
                Console.WriteLine("Exception caught:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(stackTrace);
                throw;
            }
        }

    }
}
