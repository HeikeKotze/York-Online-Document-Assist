using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class CapexUserService : ICapexUserService
    {
        private readonly dbfirstcontext _dbc;
        public CapexUserService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void AddNewCapexUser(CapexUser user)
        {
            try
            {
                _dbc.CapexUsers.Add(user);
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

        public CapexUser GetCapexUser(int id)
        {
            try
            {
                var user = _dbc.CapexUsers
                    .Where(x=>x.UserId == id)
                    .FirstOrDefault();
                if (user != null)
                {
                    return user;
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

        public List<CapexUser> GetAll()
        {
            try
            {
                List<CapexUser> users = _dbc.CapexUsers.ToList();
                return users;
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

        public List<CapexUser> GetCapexUserByBusinessUnit(int buid)
        {
            try
            {
                var users = _dbc.CapexUsers
                .Where(cu => cu.BusinessUnitId == buid)
                .Select(x => new CapexUser
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                })
                .ToList();
                return users;
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

        public List<CapexUser> GetCapexUserByInitiator(string user)
        {
            try
            {
                var cuuser = _dbc.CapexUsers
                    .Where(cu => cu.UserName == user)
                    .Select(x => new CapexUser
                    {
                        UserId= x.UserId,
                        UserName = x.UserName,
                    })
                    .ToList();
                return cuuser;
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

        public void updateNewUser(int id)
        {
            try
            {
                var user = _dbc.CapexUsers
                .Where(x => x.UserId == id)
                .FirstOrDefault();
                if (user != null)
                {
                    user.NewUser = 1;
                    _dbc.SaveChanges();
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

        public void lockUser(int id)
        {
            try
            {
                var user = _dbc.CapexUsers
                    .Where (x => x.UserId == id)
                    .FirstOrDefault();
                if(user != null)
                {
                    user.Lock = 0;
                    _dbc.SaveChanges();
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

        public int getUserIDByName(string userName)
        {
            try
            {
                var user = _dbc.CapexUsers
                    .Where(x=>x.UserName == userName)
                    .FirstOrDefault();
                if( user != null)
                {
                    return user.UserId;
                }
                else
                {
                    return 0;
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
    }
}
