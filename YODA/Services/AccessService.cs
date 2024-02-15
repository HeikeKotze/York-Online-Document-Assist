using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using YODA.Pages.CapexComponents;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class AccessService : IAccessService
    {
        private readonly dbfirstcontext _dbc;
        public AccessService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void AddUserAccess(UserAccess userAccess)
        {
            try
            {
                _dbc.UserAccesses.Add(userAccess);
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

        public List<UserAccess> GetAllUserAccess(int id)
        {
            try
            {
                var accesslist = _dbc.UserAccesses
                .Where(x => x.UserID == id)
                .ToList();
                return accesslist;
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

        public UserAccess GetUserAccess(int id, int moduleid)
        {
            try
            {
                var userAccess = _dbc.UserAccesses
                    .Where(x => x.UserID == id && x.ModuleID == moduleid)
                    .FirstOrDefault();
                return userAccess;

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

        public void setUserAccess(int id, int accesstype)
        {
            try
            {
                var useraccess = _dbc.UserAccesses
                .Where(x => x.UserID == id)
                .FirstOrDefault();
                if (useraccess != null)
                {
                    useraccess.AccessTypeID = accesstype;
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
    
    }
}
