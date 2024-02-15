using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class InstructionService : IInstructionService
    {
        private readonly dbfirstcontext _dbc;
        public InstructionService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }
        public List<FkSignatoriesCapex> GetInstructions(int id)
        {
            try
            {
                var signatories = _dbc.FkSignatoriesCapexes
            .Where(s => s.FkScCapexForm == id)
            .Select(s => new FkSignatoriesCapex
            {
                FkScReason = s.FkScReason,
                FkScSignatoryId = s.FkScSignatoryId,
            })
            .ToList();
                return signatories;
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
    }
}
