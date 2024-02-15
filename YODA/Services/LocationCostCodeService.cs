using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class LocationCostCodeService : ILocationCostCodeService
    {
        private readonly dbfirstcontext _dbc;
        public LocationCostCodeService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }
        public List<LocationCostCode> GetLocationCostCodes()
        {
            try
            {
                var locationCostCodes = _dbc.LocationCostCodes
                    .Where(x=>x.RecStatus == 1)
                    .Select(x => new LocationCostCode
                    {
                        LocationCostCodeId = x.LocationCostCodeId,
                        LocationCostCodeName = x.LocationCostCodeName,
                    })
                    .ToList();

                return locationCostCodes;
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
