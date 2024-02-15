using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class SignatoryService : ISignatoryService
    {
        private readonly dbfirstcontext _dbc;
        public SignatoryService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public bool BoardInSignatories(List<FkSignatoriesCapex> list)
        {
                var capexusers = _dbc.CapexUsers
                .Where(x => x.UserName == "111111")
                .Select(x=>x.UserId)
                    .ToList();

            bool result = false;

                foreach(var item in list)
                {
                    if(capexusers.Contains(item.FkScSignatoryId))
                    {
                        result = true;
                    break;
                    }
                    else
                    {
                        result = false;
                    }
                }

                return result;
        }

        public void deleteSignatoriesByCapex(int? id)
        {
            try
            {
                var SignatoriesToDelete = _dbc.FkSignatoriesCapexes
                    .Where(signatory => signatory.FkScCapexForm == id)
                    .ToList();

                _dbc.FkSignatoriesCapexes.RemoveRange(SignatoriesToDelete);
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

        public List<FkSignatoriesCapex> findSignatoriesByCapex(int? id)
        {
            try
            {
                var signatories = _dbc.FkSignatoriesCapexes
                    .Where(signatory => signatory.FkScCapexForm == id)
                    .Select(signatory => new FkSignatoriesCapex
                    {
                        FkScSignatoryId = signatory.FkScSignatoryId,
                        FkScSignatoryRoleId = signatory.FkScSignatoryRoleId,
                        FkScSignatoryDate = signatory.FkScSignatoryDate,
                        FkScSignedConfirmation = signatory.FkScSignedConfirmation,
                        FkScReason = signatory.FkScReason,
                        FkScCapexForm = signatory.FkScCapexForm
                    })
                    .ToList();

                return signatories;
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

        public int GetCorrespondingRoleId(string name)
        {
            try
            {
                var user = _dbc.CapexUsers
                    .Where(u => u.UserName == name)
                    .Select(u => u.RoleId)
                    .FirstOrDefault();

                return (int)user;
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

        public string GetCorrespondingRoleName(string name)
        {
            try
            {
                var userId = _dbc.CapexUsers
                    .Where(u => u.UserName == name)
                    .Select(u => u.RoleId)
                    .FirstOrDefault();

                if (userId != null)
                {
                    var roleName = _dbc.Roles
                        .Where(r => r.RoleId == userId)
                        .Select(r => r.RoleName)
                        .FirstOrDefault();

                    return roleName ?? "no role";
                }
                else
                {
                    return "no role";
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

        public int GetRoleID(int id)
        {
            try
            {
                var item = _dbc.CapexUsers
                    .Where (u => u.RoleId == id)
                    .FirstOrDefault();
                if (item != null)
                {
                    var name = _dbc.Roles
                        .Where(x=>x.RoleId == item.RoleId)
                        .Select(x => x.RoleId)
                        .FirstOrDefault();
                    return name;
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

        public string? GetRoleName(int? roleId)
        {
            try
            {
                var name = _dbc.Roles
                    .Where(u => u.RoleId == roleId)
                    .Select(u => u.RoleName)
                    .FirstOrDefault();

                return name ?? "no role";
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

        public string GetRoleName(int roleId)
        {
            var roleName = _dbc.Roles
                .Where(x=>x.RoleId == roleId)
                .Select(x => x.RoleName) .FirstOrDefault();
            if(roleName != null)
            {
                return roleName;
            }
            else
            {
                return "";
            }
        }

        public string? GetUserName(int? userId)
        {
            try
            {
                var name = _dbc.CapexUsers
                    .Where(u => u.UserId == userId)
                    .Select(u => u.UserName)
                    .FirstOrDefault();

                return name ?? "user not found";
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

        public int RetrieveEmpID(string name)
        {
            try
            {
                var item = _dbc.Employees
                    .Where(x=>x.FullName == name)
                    .FirstOrDefault();
                if(item != null)
                {
                    return item.EmployeeID;
                }
                else { return 0; }
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

        public string RetrieveEmpName(int sigid)
        {
            try
            {
                var user = _dbc.CapexUsers
                    .Where(x=>x.UserId == sigid)
                    .FirstOrDefault();
                if(user != null)
                {
                    var emp = _dbc.Employees
                        .Where(x=>x.EmployeeNumber == user.UserName)
                        .FirstOrDefault();
                    if(emp != null)
                    {
                        return emp.FullName;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string stackTrace = new StackTrace(ex).ToString();

                // Log or display the stack trace
                Console.WriteLine("Exception caught:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(stackTrace);
                throw;
            }
        }

        public string RetrieveEmpNum(string name)
        {
            try
            {
                var emp = _dbc.Employees
                    .Where(x=>x.FullName == name)
                    .FirstOrDefault();
                if(emp != null)
                {
                    return emp.EmployeeNumber;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex) 
            {
                string stackTrace = new StackTrace(ex).ToString();

                // Log or display the stack trace
                Console.WriteLine("Exception caught:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(stackTrace);
                throw;
            }
        }

        public int RetrieveRoleID(string name)
        {
            try
            {
                var roleid = _dbc.Employees
                    .Where(x=>x.FullName == name)
                    .Select(x => x.RoleID)
                    .FirstOrDefault();
                if(roleid != null)
                {
                    return (int)roleid;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                string stackTrace = new StackTrace(ex).ToString();

                // Log or display the stack trace
                Console.WriteLine("Exception caught:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(stackTrace);
                throw;
            }
        }

        public string RetrieveRoleName(string name)
        {
            try
            {
                var item = _dbc.Employees
                    .Where(x => x.FullName == name)
                    .Select(x=>x.RoleID)
                    .FirstOrDefault();
                if(item != null)
                {
                    var rolename = _dbc.Roles
                        .Where(x=>x.RoleId == item)
                        .Select(x=>x.RoleName) 
                        .FirstOrDefault();

                    if(rolename != null)
                    {
                        return rolename;
                    }
                    else
                    {
                        return "No Role";
                    }
                }
                else
                {
                    return "Could not find";
                }
            }
            catch (Exception ex)
            {
                string stackTrace = new StackTrace(ex).ToString();

                // Log or display the stack trace
                Console.WriteLine("Exception caught:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(stackTrace);
                throw;
            }
        }

        public int returnCEOCFOEmployeeID(int roleid)
        {
            var employee = _dbc.Employees
                .Where(x=>x.RoleID == roleid)
                .Select(x=>x.EmployeeID)
                .FirstOrDefault();
            return employee;
        }


        public void saveSignatories(List<FkSignatoriesCapex> signatories)
        {
            try
            {
                foreach (var item in signatories)
                {
                    _dbc.FkSignatoriesCapexes.Add(item);
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
