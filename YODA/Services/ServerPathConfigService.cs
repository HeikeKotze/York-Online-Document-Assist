using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class ServerPathConfigService : IServerPathConfigService
    {
        private readonly dbfirstcontext _dbc;
        public ServerPathConfigService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }
        public ServerPathConfig GetServerPathConfig(int id)
        { 
            try
            {
                var path = _dbc.ServerPathConfigs
                .Where(x => x.Id == id)
                .FirstOrDefault();
                if (path != null)
                {
                    return path;
                }
                else
                {
                    return null;
                }

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
