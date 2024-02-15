using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using YODA.Repos;
using YODA.Repos.Models;
using System.Linq;
using YODA.Pages.CapexComponents;
using System.Diagnostics;
using Blazorise;

namespace YODA.Services
{
    public class CapexFormService : ICapexFormService
    {
        private readonly dbfirstcontext _dbc;
        public CapexFormService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }
        public bool AddUpdateCapex(CapexForm capexForm)
        {
            try
            {
                if (capexForm.CapexId == 0)
                {
                    _dbc.CapexForms.Add(capexForm);
                }
                else
                {
                    _dbc.CapexForms.Update(capexForm);
                }
                _dbc.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool DeleteCapex(int id)
        {
            try
            {
                var capexForm = FindCapexById(id);

                if(capexForm == null)
                    return false;
                _dbc.CapexForms.Remove(capexForm);
                _dbc.SaveChanges();
                return true;
                
            }
            catch
            {
                return false;
            }
        }

        public CapexForm FindCapexById(int id)
        {
            try
            {
                return _dbc.CapexForms.Find(id);
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

        public List<CapexForm> GetAllCapexForms()
        {
            try
            {
                var list = _dbc.CapexForms
                    .Where(x => x.RecStatus == 1)
                    .Distinct()
                    .ToList();
                return list;
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


        public List<CapexForm> GetAllCapexFormsForBusinessUnit(int businessUnit, int department)
        {
            try
            {
                var list = _dbc.CapexForms
                    .Where(x=>x.SiteId == businessUnit && x.DepartmentID == department && x.RecStatus == 1)
                    .Distinct()
                    .ToList();
                return list;
                //var result = from capexForm in _dbc.CapexForms
                //             join capexUser in _dbc.CapexUsers on capexForm.Initiator equals capexUser.UserName
                //             where capexUser.BusinessUnitId == businessUnit
                //             orderby capexForm.CapexTitle
                //             select capexForm;
                //return result.ToList();
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


        public List<CapexForm> GetAllCapexFormsForInitiator(string initiator)
        {
            string empnum = "";
            try
            {
                var user = _dbc.Employees
                    .Where(x => x.EmployeeNumber == initiator)
                    .FirstOrDefault();
                if (user != null)
                {
                    var result = from capexForm in _dbc.CapexForms
                                 where capexForm.Initiator == user.FullName
                                 orderby capexForm.CapexTitle
                                 select capexForm;
                    return result.ToList();
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


        public List<CapexForm> GetCapexForAnalytics()
        {
            try
            {
                var result = _dbc.CapexForms
                    .Where(cf => cf.CapexOutcome >= 0)
                    .Select(cf => new CapexForm
                    {
                        CapexId = cf.CapexId,
                        CapexTitle = cf.CapexTitle,
                        TotalCost = cf.TotalCost,
                        CapexOutcome = cf.CapexOutcome,
                        CompanyId = cf.CompanyId,
                    })
                    .ToList();
                return result;
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


        public List<CapexForm> GetCapexForApproved()
        {
            try
            {
                var capexList = _dbc.CapexForms
                    .Where(c => c.CapexOutcome == 2 && c.RecStatus == 1)
                    .Select(c => new CapexForm
                    {
                        CapexId = c.CapexId,
                        CapexTitle = c.CapexTitle,
                        Initiator = c.Initiator
                    })
                    .ToList();

                return capexList;
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


        public List<CapexForm> GetCapexForApprovedBusinessUnit(int businessUnit, int department)
        {
            try
            {
                var forms = _dbc.CapexForms
                    .Where(x => x.SiteId == businessUnit && x.DepartmentID == department && x.RecStatus == 1)
                    .Distinct()
                    .Select(x => new CapexForm
                    {
                        CapexId = x.CapexId,
                        CapexTitle = x.CapexTitle,
                        Initiator = x.Initiator
                    })
                .ToList();
                
                if(forms.Count != 0)
                {
                    return forms;
                }
                else
                {
                    return new List<CapexForm>();
                }
                //var capexList = (from capexForm in _dbc.CapexForms
                //                 join capexUser in _dbc.CapexUsers on capexForm.Initiator equals capexUser.UserName
                //                 where capexForm.CapexAuthorizationConfirm == 1
                //                       && capexForm.RecStatus == 1
                //                       && capexForm.CapexOutcome == 2
                //                       && capexUser.BusinessUnitId == businessUnit
                //                 select new CapexForm
                //                 {
                //                     CapexId = capexForm.CapexId,
                //                     CapexTitle = capexForm.CapexTitle,
                //                     Initiator = capexForm.Initiator
                //                 })
                //    .Distinct()
                //    .ToList();

                //return capexList;
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


        public List<CapexForm> GetCapexForApprovedInitiator(string initiator)
        {
            string empnum = string.Empty;
            
            try
            {
                var user = _dbc.Employees.Where(x => x.EmployeeNumber == initiator)
                .FirstOrDefault();
                if (user != null)
                {
                    var capexList = _dbc.CapexForms
                        .Where(cf => cf.CapexAuthorizationConfirm == 1 && cf.RecStatus == 1 && cf.CapexOutcome == 2 && cf.Initiator == user.FullName)
                        .Select(cf => new CapexForm
                        {
                            CapexId = cf.CapexId,
                            CapexTitle = cf.CapexTitle,
                            Initiator = cf.Initiator
                        })
                        .ToList();

                    return capexList;
                }
                else return null;
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

        public List<CapexForm> GetCapexForAwaitingApproval()
        {
            try
            {
                var capexList = _dbc.CapexForms
                    .Where(c => c.CapexAuthorizationConfirm == 1 && c.CapexOutcome == -1 && c.RecStatus == 1)
                    .Select(c => new CapexForm
                    {
                        CapexId = c.CapexId,
                        CapexTitle = c.CapexTitle,
                        Initiator = c.Initiator,
                        TotalCost = c.TotalCost,
                    })
                    .ToList();

                return capexList;
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

        public List<CapexForm> GetCapexForAwaitingApprovalBusinessUnit(int businessUnit)
        {
            try
            {
                var capexList = (from capexForm in _dbc.CapexForms
                                 join capexUser in _dbc.CapexUsers on capexForm.Initiator equals capexUser.UserName
                                 where capexForm.CapexAuthorizationConfirm == 1
                                       && capexForm.RecStatus == 1
                                       && capexForm.CapexOutcome == -1
                                       && capexUser.BusinessUnitId == businessUnit
                                 select new CapexForm
                                 {
                                     CapexId = capexForm.CapexId,
                                     CapexTitle = capexForm.CapexTitle,
                                     Initiator = capexForm.Initiator
                                 })
                    .Distinct()
                    .ToList();

                return capexList;
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

        public List<CapexForm> GetCapexForAwaitingApprovalInitiator(int initiator)
        {

            try
            {
                var user = _dbc.Employees
                    .Where(x=>x.EmployeeID == initiator)
                    .Select(x => new Employee
                    {
                        EmployeeID = x.EmployeeID,
                        EmployeeNumber = x.EmployeeNumber
                    })
                .FirstOrDefault();

                if (user != null)
                {
                    var capexList = _dbc.CapexForms
                    .Where(cf => cf.CapexAuthorizationConfirm == 1 && cf.RecStatus == 1 && cf.CapexOutcome == -1 && cf.Initiator == user.FullName)
                    .Select(cf => new CapexForm
                    {
                        CapexId = cf.CapexId,
                        CapexTitle = cf.CapexTitle,
                        Initiator = cf.Initiator
                    })
                    .ToList();

                    return capexList;
                }
                else return new List<CapexForm>();
                                   
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

        public List<CapexForm> GetCapexForCompleted()
        {
            try
            {
                var capexList = _dbc.CapexForms
                    .Where(cf => cf.CapexOutcome >= 0 && cf.RecStatus == 1)
                    .Select(cf => new CapexForm
                    {
                        CapexId = cf.CapexId,
                        CapexTitle = cf.CapexTitle,
                        Initiator = cf.Initiator,
                        CapexOutcome = cf.CapexOutcome
                    })
                    .ToList();

                return capexList;
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

        public List<CapexForm> GetCapexForCompletedBusinessUnit(int businessUnit, int department)
        {
            try
            {
                var forms = _dbc.CapexForms
                    .Where(x => x.SiteId == businessUnit && x.DepartmentID == department && x.RecStatus == 1)
                    .Distinct()
                    .Select(x=>new CapexForm
                    {
                        CapexId=x.CapexId,
                        CapexTitle = x.CapexTitle,
                        Initiator = x.Initiator,
                        CapexOutcome = x.CapexOutcome
                    })
                    .ToList();
                if( forms.Count != 0)
                {
                    return forms;
                }
                else
                {
                    return new List<CapexForm>();
                }
                #region previous not used
                //var capexList = (from capexForm in _dbc.CapexForms
                //                 join capexUser in _dbc.CapexUsers on capexForm.Initiator equals capexUser.UserName
                //                 join employee in _dbc.Employees on capexForm.Initiator equals employee.FullName
                //                 where capexForm.CapexAuthorizationConfirm == 1
                //                       && capexForm.RecStatus == 1
                //                       && capexForm.CapexOutcome >= 0
                //                       && capexUser.BusinessUnitId == businessUnit
                //                       && employee.DepartmentID == department
                //                 select new CapexForm
                //                 {
                //                     CapexId = capexForm.CapexId,
                //                     CapexTitle = capexForm.CapexTitle,
                //                     Initiator = capexForm.Initiator,
                //                     CapexOutcome = capexForm.CapexOutcome
                //                 })
                //    .Distinct()
                //    .ToList();

                //return capexList;
                #endregion
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

        public List<CapexForm> GetCapexForCompletedInitiator(string initiator)
        {
            try
            {
                var user = _dbc.Employees
                    .Where(x => x.EmployeeNumber == initiator)
                    .FirstOrDefault();
                if(user != null)
                {
                    var capexList = _dbc.CapexForms
                    .Where(cf => cf.CapexAuthorizationConfirm == 1 && cf.RecStatus == 1 && cf.CapexOutcome >= 0 && cf.Initiator == user.FullName)
                    .Select(cf => new CapexForm
                    {
                        CapexId = cf.CapexId,
                        CapexTitle = cf.CapexTitle,
                        Initiator = cf.Initiator,
                        CapexOutcome = cf.CapexOutcome
                    })
                    .ToList();

                    return capexList;
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

        public List<CapexForm> GetCapexForDeclined()
        {
            try
            {
                var capexList = _dbc.CapexForms
                    .Where(c => c.CapexOutcome == 0 && c.RecStatus == 1)
                    .Select(c => new CapexForm
                    {
                        CapexId = c.CapexId,
                        CapexTitle = c.CapexTitle,
                        Initiator = c.Initiator
                    })
                    .ToList();

                return capexList;
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

        public List<CapexForm> GetCapexForDeclinedBusinessUnit(int businessUnit, int department)
        {
            try
            {
                var forms = _dbc.CapexForms
                    .Where(x=>x.SiteId == businessUnit && x.DepartmentID == department && x.RecStatus == 1)
                    .Distinct()
                    .Select(x=> new CapexForm
                    {
                        CapexId =x.CapexId,
                        CapexTitle = x.CapexTitle,
                        Initiator = x.Initiator
                    })
                    .ToList();
                if(forms.Count != 0)
                {
                    return forms;
                }
                else
                {
                    return new List<CapexForm>(); 
                }
                //var capexList = (from capexForm in _dbc.CapexForms
                //                 join capexUser in _dbc.CapexUsers on capexForm.Initiator equals capexUser.UserName
                //                 where capexForm.CapexAuthorizationConfirm == 1
                //                       && capexForm.RecStatus == 1
                //                       && capexForm.CapexOutcome == 0
                //                       && capexUser.BusinessUnitId == businessUnit
                //                 select new CapexForm
                //                 {
                //                     CapexId = capexForm.CapexId,
                //                     CapexTitle = capexForm.CapexTitle,
                //                     Initiator = capexForm.Initiator
                //                 })
                //    .Distinct()
                //    .ToList();

                //return capexList;
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

        public List<CapexForm> GetCapexForDeclinedInitiator(string initiator)
        {
            try
            {
                var user = _dbc.Employees
                    .Where(x => x.EmployeeNumber == initiator)
                    .FirstOrDefault();
                if (user != null)
                {
                    var capexList = _dbc.CapexForms
                    .Where(cf => cf.CapexAuthorizationConfirm == 1 && cf.RecStatus == 1 && cf.CapexOutcome == 0 && cf.Initiator == user.FullName)
                    .Select(cf => new CapexForm
                    {
                        CapexId = cf.CapexId,
                        CapexTitle = cf.CapexTitle,
                        Initiator = cf.Initiator
                    })
                    .ToList();

                    return capexList;
                }
                else return null;
                
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

        public CapexForm GetCapexFormByName(string capexname)
        {
            try
            {
                return _dbc.CapexForms.FirstOrDefault(form => form.CapexTitle == capexname);
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


        public List<CapexForm> GetCapexForNotSubmitted()
        {
            try
            {
                var capexList = _dbc.CapexForms
                    .Where(cf => cf.CapexAuthorizationConfirm == 0 && cf.RecStatus == 1 && cf.CapexOutcome < 0)
                    .Select(cf => new CapexForm
                    {
                        CapexId = cf.CapexId,
                        CapexTitle = cf.CapexTitle,
                        Initiator = cf.Initiator
                    })
                    .ToList();

                return capexList;
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


        public List<CapexForm> GetCapexForNotSubmittedBusinessUnit(int businessUnit)
        {
            try
            {
                var capexList = (from capexForm in _dbc.CapexForms
                                 join capexUser in _dbc.CapexUsers on capexForm.Initiator equals capexUser.UserName
                                 where capexForm.CapexAuthorizationConfirm == 0
                                       && capexForm.RecStatus == 1
                                       && capexForm.CapexOutcome < 0
                                       && capexUser.BusinessUnitId == businessUnit
                                 select new CapexForm
                                 {
                                     CapexId = capexForm.CapexId,
                                     CapexTitle = capexForm.CapexTitle,
                                     Initiator = capexForm.Initiator
                                 })
                    .Distinct()
                    .ToList();

                return capexList;
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


        public List<CapexForm> GetCapexForNotSubmittedInitiator(string initiator)
        {
            try
            {
                var user = _dbc.Employees
                    .Where(x => x.EmployeeNumber == initiator)
                    .Select(x => new Employee
                    {
                        EmployeeID = x.EmployeeID,
                        EmployeeNumber = x.EmployeeNumber
                    })
                .FirstOrDefault();

                if (user != null)
                {
                    var capexList = _dbc.CapexForms
                    .Where(cf => cf.CapexAuthorizationConfirm == 0 && cf.RecStatus == 1 && cf.CapexOutcome < 0 && cf.Initiator == user.FullName)
                    .Select(cf => new CapexForm
                    {
                        CapexId = cf.CapexId,
                        CapexTitle = cf.CapexTitle,
                        Initiator = cf.Initiator
                    })
                    .ToList();

                    return capexList;
                }
                else
                {
                    return new List<CapexForm>();
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


        public List<CapexForm> GetCapexForOnHold()
        {
            try
            {
                var capexList = _dbc.CapexForms
                    .Where(c => c.CapexOutcome == 1 && c.RecStatus == 1)
                    .Select(c => new CapexForm
                    {
                        CapexId = c.CapexId,
                        CapexTitle = c.CapexTitle,
                        Initiator = c.Initiator
                    })
                    .ToList();

                return capexList;
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


        public List<CapexForm> GetCapexForOnHoldBusinessUnit(int businessUnit, int department)
        {
            try
            {
                var forms = _dbc.CapexForms
                    .Where(x => x.SiteId == businessUnit && x.DepartmentID == department && x.RecStatus == 1)
                    .Distinct()
                    .Select(x => new CapexForm
                    {
                        CapexId = x.CapexId,
                        CapexTitle = x.CapexTitle,
                        Initiator = x.Initiator
                    })
                    .ToList();
                if (forms.Count != 0)
                {
                    return forms;
                }
                else
                {
                    return new List<CapexForm>();
                }
                //var capexList = (from capexForm in _dbc.CapexForms
                //                 join capexUser in _dbc.CapexUsers on capexForm.Initiator equals capexUser.UserName
                //                 where capexForm.CapexAuthorizationConfirm == 1
                //                       && capexForm.RecStatus == 1
                //                       && capexForm.CapexOutcome == 1
                //                       && capexUser.BusinessUnitId == businessUnit
                //                 select new CapexForm
                //                 {
                //                     CapexId = capexForm.CapexId,
                //                     CapexTitle = capexForm.CapexTitle,
                //                     Initiator = capexForm.Initiator
                //                 })
                //    .Distinct()
                //    .ToList();

                //return capexList;
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


        public List<CapexForm> GetCapexForOnHoldInitiator(string initiator)
        {
            try
            {
                var user = _dbc.Employees
                    .Where(x => x.EmployeeNumber == initiator)
                    .FirstOrDefault();
                if(user != null)
                {
                    var capexList = _dbc.CapexForms
                    .Where(cf => cf.CapexAuthorizationConfirm == 1 && cf.RecStatus == 1 && cf.CapexOutcome == 1 && cf.Initiator == user.FullName)
                    .Select(cf => new CapexForm
                    {
                        CapexId = cf.CapexId,
                        CapexTitle = cf.CapexTitle,
                        Initiator = cf.Initiator
                    })
                    .ToList();

                    return capexList;
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


        public string GetCorrespondingACName(int? id)
        {
            try
            {
                var acName = _dbc.AssetCategories
                    .Where(ac => ac.AssetCategoryId == id)
                    .Select(ac => ac.AssetCategoryName)
                    .FirstOrDefault();

                return acName ?? "";
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


        public string GetCorrespondingBSCName(int? id)
        {
            try
            {
                var bscName = _dbc.BalanceSheetCodes
                    .Where(b => b.BalanceSheetCodeId == id)
                    .Select(b => b.BalanceSheetCodeName)
                    .FirstOrDefault();

                return bscName ?? "";
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


        public string GetCorrespondingCompanyName(int? id)
        {
            try
            {
                var legalEntity = _dbc.LegalEntities
                    .Where(e => e.LegalEntityId == id)
                    .Select(e => e.LegalEntityName)
                    .FirstOrDefault();

                return legalEntity ?? "";
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


        public string GetCorrespondingLLCName(int? id)
        {
            try
            {
                var llcName = _dbc.LocationCostCodes
                    .Where(l => l.LocationCostCodeId == id)
                    .Select(l => l.LocationCostCodeName)
                    .FirstOrDefault();

                return llcName ?? "";
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


        public string GetCorrespondingPCName(int? id)
        {
            try
            {
                var pcName = _dbc.ProjectCategories
                    .Where(pc => pc.ProjectCategoryId == id)
                    .Select(pc => pc.ProjectCategoryName)
                    .FirstOrDefault();

                return pcName ?? "";
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


        public string GetCorrespondingSiteName(int? id)
        {
            try
            {
                var siteName = _dbc.Sites
                    .Where(s => s.SiteId == id)
                    .Select(s => s.SiteName)
                    .FirstOrDefault();

                return siteName ?? "";
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


        public void PutFormOnHold(int? id, string reason, int? userId)
        {
            try
            {
                short signConfirmation = 1; // on hold
                DateTime signDate = DateTime.Now;
                short outcome = 1;

                // Add signatory id------------------------------------------
                // Save signatory reason
                var signatory = _dbc.FkSignatoriesCapexes
                    .FirstOrDefault(s => s.FkScCapexForm == id && s.FkScSignatoryId == userId);

                if (signatory != null)
                {
                    signatory.FkScReason = reason;
                    signatory.FkScSignedConfirmation = signConfirmation;
                    signatory.FkScSignatoryDate = signDate;
                }

                // Save outcome
                var capexForm = _dbc.CapexForms
                    .FirstOrDefault(c => c.CapexId == id);

                if (capexForm != null)
                {
                    capexForm.CapexOutcome = outcome;
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


        public void DeclineForm(int? id, string reason, int? userId)
        {
            try
            {
                short signConfirmation = 0; // Declined
                DateTime signDate = DateTime.Now;
                short outcome = 0; // Declined

                // Add signatory id-------------------------------------------
                // Save signatory reason
                var signatory = _dbc.FkSignatoriesCapexes
                    .FirstOrDefault(s => s.FkScCapexForm == id && s.FkScSignatoryId == userId);

                if (signatory != null)
                {
                    signatory.FkScReason = reason;
                    signatory.FkScSignedConfirmation = signConfirmation;
                    signatory.FkScSignatoryDate = signDate;
                }

                // Save outcome
                var capexForm = _dbc.CapexForms
                    .FirstOrDefault(c => c.CapexId == id);

                if (capexForm != null)
                {
                    capexForm.CapexOutcome = outcome;
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


        public void SignForm(int id, string username, string password, string reason, int userId)
        {
            try
            {
                // Check username and password----------------------------------
                DateTime signdate = DateTime.Now;
                short signconfirmation = 2;

                var signatory = _dbc.FkSignatoriesCapexes
                    .FirstOrDefault(s => s.FkScCapexForm == id && s.FkScSignatoryId == userId);

                if (signatory != null)
                {
                    signatory.FkScReason = reason;
                    signatory.FkScSignedConfirmation = signconfirmation;
                    signatory.FkScSignatoryDate = signdate;
                }

                _dbc.SaveChanges();

                bool allSignatoriesConfirmed = _dbc.FkSignatoriesCapexes
                    .Where(s => s.FkScCapexForm == id)
                    .All(s => s.FkScSignedConfirmation == 2);

                if (allSignatoriesConfirmed)
                {
                    // Update the CapexForm's CapexOutcome to 2
                    var capexForm = _dbc.CapexForms
                        .FirstOrDefault(form => form.CapexId == id);

                    if (capexForm != null)
                    {
                        capexForm.CapexOutcome = 2;
                        _dbc.SaveChanges();
                    }
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


        public void DeleteComments(int id, List<Comment> comments)
        {
            try
            {
                foreach (var data in comments)
                {
                    var commentsDelete = _dbc.Comments
                        .Where(c => c.FkCapexId == id)
                        .ToList();
                    _dbc.Comments.RemoveRange(commentsDelete);
                }

                _dbc.SaveChanges();
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

        public void SaveComments(int id, List<Comment> comments)
        {
            try
            {
                foreach (var data in comments)
                {
                    var comment = new Comment
                    {
                        FkCapexId = id,
                        FormSection = data.FormSection,
                        Consentee = data.Consentee,
                        Comments = data.Comments
                    };

                    _dbc.Comments.Add(comment);
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

        public void WithdrawCapex(int id)
        {
            try
            {
                var capexForm = _dbc.CapexForms.FirstOrDefault(cf => cf.CapexId == id);

                if (capexForm != null)
                {
                    capexForm.RecStatus = 101;
                    _dbc.SaveChanges();
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

        public void ChangeToModify(int id)
        {
            try
            {
                var capexForm = _dbc.CapexForms.FirstOrDefault(cf => cf.CapexId == id);

                if (capexForm != null)
                {
                    capexForm.CapexOutcome = -1;
                    capexForm.CapexAuthorizationConfirm = 0;
                    _dbc.SaveChanges();
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

        public string GetCorrespondingComanyName(int? id)
        {
            try
            {
                var legalEntity = _dbc.LegalEntities
                    .Where(e => e.LegalEntityId == id)
                    .Select(e => e.LegalEntityName)
                    .FirstOrDefault();

                return legalEntity ?? "";
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

        public string GetCorrespondingSitename(int? id)
        {
            try
            {
                var siteName = _dbc.Sites
                    .Where(s => s.SiteId == id)
                    .Select(s => s.SiteName)
                    .FirstOrDefault();

                return siteName ?? "";
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

        public List<CapexForm> CombinedDataForAnalytics(List<LegalEntity> legalEntities, List<BusinessUnit> businessUnits, List<Employee> capexUsers, List<EmployeeDepartment> empDepartments)
        {
            try
            {
                List<CapexForm> combinedData = new();

                foreach (var legalEntity in legalEntities)
                {
                    var capexFormsForLegalEntity = _dbc.CapexForms
                .Where(cf =>
                    cf.CapexAuthorizationConfirm == 1 &&
                    cf.RecStatus == 1 &&
                    cf.CapexOutcome > -1 &&
                    cf.Site.BusinessUnit.LegalEntity.LegalEntityName == legalEntity.LegalEntityName)
                .Select(cf => new CapexForm
                {
                    CapexId = cf.CapexId,
                    CapexTitle = cf.CapexTitle,
                    TotalCost = cf.TotalCost,
                    CapexOutcome = cf.CapexOutcome,
                })
                .ToList();

                 combinedData.AddRange(capexFormsForLegalEntity);
                    
                }


                foreach(var businessUnit in businessUnits)
                {
                    var capexFormsForBusinessUnit = _dbc.CapexForms
                        .Where(cf =>
                        cf.CapexAuthorizationConfirm == 1 &&
                        cf.RecStatus == 1 &&
                        cf.CapexOutcome > -1 &&
                        cf.Site.BusinessUnit.BusinessUnitName == businessUnit.BusinessUnitName)
                        .Select(cf => new CapexForm
                        {
                            CapexId = cf.CapexId,
                            CapexTitle = cf.CapexTitle,
                            TotalCost = cf.TotalCost,
                            CapexOutcome = cf.CapexOutcome,
                        })
                        .ToList() ;

                    combinedData.AddRange(capexFormsForBusinessUnit);
                }

                foreach(var user in capexUsers)
                {
                    var capexFormsForInitiator = _dbc.CapexForms
                        .Where(cf =>
                        cf.CapexAuthorizationConfirm == 1 &&
                        cf.RecStatus == 1 &&
                        cf.CapexOutcome > -1 &&
                        cf.Initiator == user.FullName)
                        .Select(cf => new CapexForm
                        {
                            CapexId = cf.CapexId,
                            CapexTitle = cf.CapexTitle,
                            TotalCost = cf.TotalCost,
                            CapexOutcome = cf.CapexOutcome,
                        })
                        .ToList();                   

                    combinedData.AddRange (capexFormsForInitiator);
                }

                //foreach(var dept in empDepartments)
                //{
                //    var capexFormsForDept = _dbc.CapexForms
                //        .Where(cf=>
                //        cf.CapexAuthorizationConfirm == 1 &&
                //        cf.RecStatus == 1 &&
                //        cf.CapexOutcome > -1 &&
                //        dept.)

                //}

                
                combinedData = RemoveDuplicates(combinedData);
                return combinedData;
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

        public int GetCapexForm(CapexForm form)
        {
            try
            {
                var item = _dbc.CapexForms.FirstOrDefault(x=>x.CapexId == form.CapexId);
                if(item != null)
                {
                    return item.CapexId;
                }
                else
                {
                    return 0;
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


        public List<CapexForm> GetCapexToSign(int user)
        {
            List<CapexForm> list = new();

            try
            {
                var formstosign = _dbc.FkSignatoriesCapexes
                    .Where(x=>x.FkScSignatoryId == user && x.FkScSignedConfirmation == null)
                    .ToList();
                foreach(var item in formstosign)
                {
                    var cx = _dbc.CapexForms
                        .Where(x => x.CapexId == item.FkScCapexForm && x.CapexAuthorizationConfirm == 1)
                        .FirstOrDefault();
                    if (cx != null)
                    {
                        list.Add(cx);
                    }                    
                }
                return list;
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

        public List<FkSignatoriesCapex> GetSignatoriesCapex(int id)
        {
            try
            {
                var sigs = _dbc.FkSignatoriesCapexes
                    .Where(x=>x.FkScCapexForm == id)
                    .ToList();
                return sigs;
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

        public List<CapexForm> RemoveDuplicates(List<CapexForm> forms)
        {
            try
            {
                HashSet<int> uniqueCapexIds = new HashSet<int>();
                List<CapexForm> uniqueForms = new List<CapexForm>();

                foreach (var form in forms)
                {
                    if (uniqueCapexIds.Add(form.CapexId))
                    {
                        // Unique CapexId, add the form to the uniqueForms list
                        uniqueForms.Add(form);
                    }
                }

                // Return the new list containing unique forms
                return uniqueForms;
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

        public void UpdateProjectNumberEtc(int capexid, string projectnumber, int balancesheetid, int locationcostid)
        {
            try
            {
                var form = _dbc.CapexForms
                    .Where(x => x.CapexId == capexid)
                    .FirstOrDefault();
                if(form != null)
                {
                    form.ProjectNumber = projectnumber;
                    form.BalanceSheetCodeId = balancesheetid;
                    form.LocationCostCodeId = locationcostid;
                    _dbc.Update(form);
                    _dbc.SaveChanges();
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

        public string GetCorrespondingDeptName(int? id)
        {
            try
            {
                var name = _dbc.EmployeeDepartments
                    .Where(x=>x.Id == id)
                    .FirstOrDefault();
                if(name != null)
                {
                    return name.DepartmentName;
                }
                else
                {
                    return "";
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

        public void UpdateDateOfPaymentForCapex(int capexid, DateTime date)
        {
            var capex = _dbc.CapexForms
                .Where(x=>x.CapexId == capexid)
                .FirstOrDefault();
            if(capex != null)
            {
                capex.PaymentDate = date;
                _dbc.CapexForms.Update(capex);
                _dbc.SaveChanges();
            }
        }

        public List<CapexForm> GetCapexFormsWhereAllHaveSigned()
        {
            var list = _dbc.CapexForms
                .Where(x=>x.RecStatus == 1 && x.PaymentDate <= DateTime.Now && x.ProjectNumber == null)
                .ToList();

            List<CapexForm> listtosend = new();

            foreach (var capex in list)
            {
                var signatorylist = _dbc.FkSignatoriesCapexes
                    .Where(x => x.FkScCapexForm == capex.CapexId)
                    .ToList();

                if(signatorylist != null)
                {
                    if(signatorylist.All(sig => sig.FkScSignedConfirmation == 2))
                    {
                        listtosend.Add(capex);
                    }
                }
            }
            return listtosend;
        }

        public List<CapexForm> GetCapexWhereCapexTitleHas(string word)
        {
            var list = _dbc.CapexForms
                .Where(x => x.CapexTitle.Contains(word))
                .OrderByDescending(x => x.CapexId)
                .ToList();
            return list;
        }
    }
}
