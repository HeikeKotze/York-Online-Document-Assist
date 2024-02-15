using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YODA.Pages.CapexComponents;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class RoleService : IRoleService
    {
        private readonly dbfirstcontext _dbc;
        public RoleService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public string GetRoleById(int id)
        {
            try
            {
                var role = _dbc.Roles
                .Where(x => x.RoleId == id)
                .FirstOrDefault();
                if (role != null)
                {
                    return role.RoleName;
                }
                else
                {
                    return "";
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

        public List<Role> GetRoles()
        {
            try
            {
                var roles = _dbc.Roles
                    .Select (r => new Role
                    {
                        RoleId = r.RoleId,
                        RoleName = r.RoleName,
                    })
                    .ToList();
                return roles;
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
