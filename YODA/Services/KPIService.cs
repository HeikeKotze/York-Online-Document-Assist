using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class KPIService : IKPIService
    {
        private readonly dbfirstcontext _dbc;
        public KPIService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void deleteKPIsByCapex(int? id)
        {
            try
            {
                var kpisToDelete = _dbc.FkKpicapexes
                    .Where(kpi => kpi.FkKcCapexForm == id)
                    .ToList();

                _dbc.FkKpicapexes.RemoveRange(kpisToDelete);
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

        public List<FkKpicapex> findKPIsByCapex(int? id)
        {
            try
            {
                var kpis = _dbc.FkKpicapexes
                    .Where(kpi => kpi.FkKcCapexForm == id)
                    .Select(kpi => new FkKpicapex
                    {
                        FkKcKpi = kpi.FkKcKpiNavigation.Kpiid,
                        FkKcDescription = kpi.FkKcDescription,
                        FkKcCapexForm = kpi.FkKcCapexForm,
                        //FkKcId = kpi.FkKcId, // You can uncomment this line if needed
                    })
                    .ToList();

                return kpis;
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

        public List<Kpi> GetAllKPIs()
        {
            try
            {
                var kpis = _dbc.Kpis
                    .Where(x=>x.RecStatus == 1)
                    .Select(x => new Kpi
                    {
                        Kpiid = x.Kpiid,
                        Kpiname = x.Kpiname
                    })
                    .ToList();

                return kpis;
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

        public string getKPItype(int? id)
        {
            try
            {
                var type = _dbc.Kpis
                    .Where(u => u.Kpiid == id)
                    .Select(u => u.Kpiname)
                    .FirstOrDefault();

                return type;
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

        public void saveKPI(List<FkKpicapex> kpi)
        {
            try
            {
                foreach (var item in kpi)
                {
                    _dbc.FkKpicapexes.Add(item);
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
