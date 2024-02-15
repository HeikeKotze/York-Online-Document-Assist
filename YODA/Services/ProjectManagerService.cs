using Microsoft.Identity.Client;
using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class ProjectManagerService : IProjectManagerService
    {
        private readonly dbfirstcontext _dbc;
        public ProjectManagerService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }
        public List<CapexUser> GetUsers()
        {
            try
            {
                var capexUsers = _dbc.CapexUsers
                    .Select(x => new CapexUser
                    {
                        UserId = x.UserId,
                        UserName = x.UserName
                    })
                    .ToList();

                return capexUsers;
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
