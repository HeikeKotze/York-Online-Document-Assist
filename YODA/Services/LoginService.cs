using DocumentFormat.OpenXml.InkML;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Ocsp;
using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YODA.Services
{
    public class LoginService : ILoginService
    {
        private readonly dbfirstcontext _dbc;
        public LoginService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void AddRequestPassword(RequestPassword qp)
        {
            _dbc.RequestPassword.Add(qp);
            _dbc.SaveChanges();
        }

        public void ChangePassword(int id, string password)
        {
            var user = _dbc.CapexUsers
                .Where(x=> x.UserId == id)
                .FirstOrDefault();
            if (user != null)
            {
                user.UserPassword = password;
                _dbc.SaveChanges();

            }
        }

        public void ChangePasswordFromRequest(string username, string password)
        {
            var user = _dbc.CapexUsers
                .Where(x=>x.UserName == username)
                .FirstOrDefault();
            if (user != null)
            {
                if(user.Lock == 0)
                {
                    user.Lock = 1;
                }
                
                user.UserPassword = password;
                _dbc.SaveChanges();

            }
        }

        public bool checkedRequestForExpiryDate(RequestPassword qp)
        {
            var item = _dbc.RequestPassword
                .Where(x=>x.Id == qp.Id)
                .FirstOrDefault();
            if (item != null)
            {
                DateTime now = DateTime.Now;
                TimeSpan difference = (TimeSpan)(now - item.DateRequested);
                if (difference.TotalHours <= 3 && difference.TotalHours >= 0)
                return true;
                else return false;
            }
            return false;
        }

        public bool checkEmailAddressAndEmployeeNumberMatch(string empnumber, string email)
        {
            var emp = _dbc.Employees
                .Where(x=>x.EmployeeNumber == empnumber && x.EmailAddress == email)
                .FirstOrDefault();
            if (emp != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkIfPasswordExists(string password)
        {
               var user = _dbc.CapexUsers
              .Where(x => x.UserPassword == password)
              .FirstOrDefault();
                if (user != null)
                    return true;
                return false;                         
        }

        public bool CheckRequestCodeAndEmpNumber(string code, int empid)
        {

            var item = _dbc.RequestPassword
                .Where(x => x.EmpID == empid && x.Code == code)
                .FirstOrDefault();

            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteRequestPassword(int id)
        {
            var list = _dbc.RequestPassword
                .Where(x => x.EmpID == id)
                .ToList();

            foreach (var request in list)
            {
                _dbc.RequestPassword.Remove(request);
                
            }
            _dbc.SaveChanges();
        }


        public RequestPassword GetRequestPassword(string code, int empid)
        {
            var request = _dbc.RequestPassword
                .Where(x=>x.EmpID == empid && x.Code==code)
                .FirstOrDefault();
            if (request != null) return request;
            else return new RequestPassword();
        }

        public CapexUser LoginConfirmation(string username, string password, bool success)
        {
            try
            {
                var result = new CapexUser();

                using (var context = new dbfirstcontext())
                {
                    var user = _dbc.CapexUsers
                        .SingleOrDefault(u => u.UserName == username && u.UserPassword == password);

                    if (user != null && user.Lock != 0)
                    {
                        result.Success = true;
                        result.UserId = user.UserId;
                        result.BusinessUnitId = user.BusinessUnitId;
                        result.UserName = user.UserName;
                        result.UserPassword = user.UserPassword;
                        result.NewUser = user.NewUser;
                    }
                    else
                    {
                        result.Success = false;
                    }
                }

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

        public void UpdateRequestPassword(string code, int empid)
        {
            var item = _dbc.RequestPassword
                .Where(x => x.Code == code && x.EmpID == empid)
                .OrderByDescending(x=>x.Id)
                .Last();

            if (item != null)
            {
                _dbc.RequestPassword.Update(item);
                _dbc.SaveChanges();
            }
            else
            {
                _dbc.SaveChanges(false);
            }
            
        }
    }
}
