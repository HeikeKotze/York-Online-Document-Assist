using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class RiskService: IRiskService
    {
        private readonly dbfirstcontext _dbc;
        public RiskService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void deleteRisksByCapex(int? id)
        {
            try
            {
                var risksToDelete = _dbc.Risks
                    .Where(risksToDelete => risksToDelete.FkCapexId == id)
                    .ToList();

                _dbc.Risks.RemoveRange(risksToDelete);
                _dbc.SaveChanges();
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

        public List<Risk> findRisksByCapex(int? id)
        {
            try
            {
                var risks = _dbc.Risks
                    .Where(risk => risk.FkCapexId == id)
                    .Select(risk => new Risk
                    {
                        RiskDescription = risk.RiskDescription,
                        ImpactOn = risk.ImpactOn,
                        ConsequenceClassification = risk.ConsequenceClassification,
                        LikelihoodClassification = risk.LikelihoodClassification,
                        MitigatingStrategy = risk.MitigatingStrategy,
                    })
                    .ToList();

                return risks;
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

        public void saveRisks(List<Risk> risks)
        {
            try
            {
                foreach (var item in risks)
                {
                    _dbc.Risks.Add(item);
                }

                _dbc.SaveChanges();
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
