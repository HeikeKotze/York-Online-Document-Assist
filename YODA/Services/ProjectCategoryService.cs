using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        private readonly dbfirstcontext _dbc;
        public ProjectCategoryService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }
        public List<ProjectCategory> GetProjectCategories()
        {
            try
            {
                var projectCategories = _dbc.ProjectCategories
                    .Where(x=>x.RecStatus == 1)
                    .Select(x => new ProjectCategory
                    {
                        ProjectCategoryId = x.ProjectCategoryId,
                        ProjectCategoryName = x.ProjectCategoryName,
                    })
                    .ToList();

                return projectCategories;
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
