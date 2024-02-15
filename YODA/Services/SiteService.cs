using System;
using YODA.Repos;
using YODA.Repos.Models;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace YODA.Services
{
    public class SiteService : ISiteService
    {
        private readonly dbfirstcontext _dbc;
        public SiteService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }
        public List<Site> GetSites()
        {
            try
            {
                var sites = _dbc.Sites
                    .Where(x=>x.RecStatus == 1)
                    .Select(x => new Site
                    {
                        SiteId = x.SiteId,
                        SiteName = x.SiteName
                    })
                    .ToList();

                return sites;
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

        string ISiteService.GetCorrespondingSiteName(int? id)
        {
            try
            {
                var siteName = _dbc.Sites
                    .Where(s => _dbc.CapexForms.Any(r => r.SiteId == s.SiteId && r.SiteId == id))
                    .Select(s => s.SiteName)
                    .FirstOrDefault();

                return siteName ?? string.Empty;
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

        int ISiteService.GetCorrespondingSiteID(string? siteName)
        {
            try
            {
                if (siteName != null)
                {
                    int? siteId = _dbc.Sites
                        .Where(s => s.SiteName == siteName)
                        .Select(s => (int?)s.SiteId)
                        .FirstOrDefault();

                    return siteId ?? 0; // Return 0 or another default value if not found
                }
                else
                {
                    return 0; // Return a default value for null siteName
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

        public List<Site> GetSitesForBusinessUnit(int buid)
        {
            try
            {
                var sites = _dbc.Sites
                    .Where(x=>x.BusinessUnitId == buid)
                    .Select(site => new Site
                    {
                        SiteId = site.SiteId,
                        SiteName = site.SiteName,
                    })
                    .Distinct()
                    .ToList();
                return sites;

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

        public List<Site> GetSitesForInitiator(string user)
        {
            try
            {
                var result = (from capexUser in _dbc.CapexUsers
                              where capexUser.UserName == user
                              join businessUnit in _dbc.BusinessUnits on capexUser.BusinessUnitId equals businessUnit.BusinessUnitId
                              join site in _dbc.Sites on businessUnit.BusinessUnitId equals site.BusinessUnitId
                              select new Site
                              {
                                  SiteId = site.SiteId,
                                  SiteName= site.SiteName,
                              }).ToList();

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
    }
}
