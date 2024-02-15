using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly dbfirstcontext _dbc;
        public BusinessUnitService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public BusinessUnit GetBusinessUnitById(int id)
        {
            try
            {
                var unit = _dbc.BusinessUnits
                    .Where(x=>x.BusinessUnitId == id)
                    .FirstOrDefault();
                if(unit != null)
                {
                    return unit;
                }
                else
                {
                    return new BusinessUnit();
                }
            }
            catch(Exception ex)
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

        public List<BusinessUnit> GetBusinessUnitForBusinessUnit(int buid)
        {
            try
            {
                List<BusinessUnit> businessUnits = _dbc.BusinessUnits
                    .Where(bu => bu.BusinessUnitId == buid)
                    .Select(bu => new BusinessUnit
                    {
                        BusinessUnitId = bu.BusinessUnitId,
                        BusinessUnitName = bu.BusinessUnitName,
                    })
                    .Distinct()
                    .ToList();
                return businessUnits;
            }
            catch(Exception ex)
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


        public List<BusinessUnit> GetBusinessUnitForInitiator(string user)
        {
            try
            {
                var result = (from capexUser in _dbc.CapexUsers
                              where capexUser.UserName == user
                              join businessUnit in _dbc.BusinessUnits on capexUser.BusinessUnitId equals businessUnit.BusinessUnitId
                              select new BusinessUnit
                              {
                                  BusinessUnitId = businessUnit.BusinessUnitId,
                                  BusinessUnitName= businessUnit.BusinessUnitName,
                              }).ToList();

                return result;
            }
            catch(Exception ex)
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

        public List<BusinessUnit> GetBusinessUnitList()
        {
            try
            {
                return _dbc.BusinessUnits
                    .Where(x=>x.RecStatus == 1)
                    .Select(x => new BusinessUnit
                    {
                        BusinessUnitId = x.BusinessUnitId,
                        BusinessUnitName = x.BusinessUnitName,
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
