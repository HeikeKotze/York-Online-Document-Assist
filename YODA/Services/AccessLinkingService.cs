using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YODA.Pages.CapexComponents;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class AccessLinkingService : IAccessLinkingService
    {
        private readonly dbfirstcontext _dbc;
        public AccessLinkingService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void AddAccessLinking(AccessLinking link)
        {
            if(link !=  null)
            {
                _dbc.AccessLinks.Add(link);
                _dbc.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }
            
        }

        public AccessLinking GetAccessLinking(AccessLinking accessLinking)
        {
            var link = _dbc.AccessLinks
                .Where(x => x.BusinessUnitID == accessLinking.BusinessUnitID && x.DepartmentID == accessLinking.DepartmentID && x.RoleID == accessLinking.RoleID && x.ModuleID == accessLinking.ModuleID && x.AccessTypeID == accessLinking.AccessTypeID)
                .FirstOrDefault();
            if(link!= null)
            {
                return link;
            }
            else
            {
                return new AccessLinking();
            }
        }

        public AccessLinking GetAccessLinkingForID(int id)
        {
            try
            {
                var item = _dbc.AccessLinks
                    .Where(x=>x.Id == id)
                    .FirstOrDefault();

                if (item != null)
                {
                    return item;
                }
                else
                {
                    return new AccessLinking();
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



        public bool GetIfLinkExists(AccessLinking accessLinking)
        {
            var id = _dbc.AccessLinks
                .Where(x => x.BusinessUnitID == accessLinking.BusinessUnitID
                && x.DepartmentID == accessLinking.DepartmentID
                && x.RoleID == accessLinking.RoleID
                && x.ModuleID == accessLinking.ModuleID
                && x.AccessTypeID == accessLinking.AccessTypeID)
                .FirstOrDefault();
            if (id != null)
            {
                return true;
            }
            else return false;
        }

        public List<AccessLinking> GetSpecificAccessLinkings(AccessLinking accessLinking)
        {
            var links = _dbc.AccessLinks
                .Where(x => x.BusinessUnitID == accessLinking.BusinessUnitID && x.DepartmentID == accessLinking.DepartmentID && x.RoleID == accessLinking.RoleID)
                .ToList();
            if(links != null)
            {
                return links;
            }
            else
            {
                return new List<AccessLinking>(); 
            }
        }

        public int GetSpecificLinkingID(AccessLinking accessLinking)
        {
            var id = _dbc.AccessLinks
                .Where(x=>x.BusinessUnitID == accessLinking.BusinessUnitID
                && x.DepartmentID == accessLinking.DepartmentID
                && x.RoleID == accessLinking.RoleID
                && x.ModuleID == accessLinking.ModuleID
                && x.AccessTypeID == accessLinking.AccessTypeID)
                .FirstOrDefault();
            if(id != null)
            {
                return id.Id;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
