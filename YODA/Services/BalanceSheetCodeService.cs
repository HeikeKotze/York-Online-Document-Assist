using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class BalanceSheetCodeService : IBalanceSheetCodeService
    {
        private readonly dbfirstcontext _dbc;
        public BalanceSheetCodeService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }
        public List<BalanceSheetCode> GetBalanceSheetCodes()
        {
            try
            {
                return _dbc.BalanceSheetCodes
                    .Where(x=>x.RecStatus == 1)
                    .Select(x => new BalanceSheetCode
                    {
                        BalanceSheetCodeId = x.BalanceSheetCodeId,
                        BalanceSheetCodeName = x.BalanceSheetCodeName,
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
