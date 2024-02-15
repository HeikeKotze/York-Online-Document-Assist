using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YODA.Services
{
    public class LegalEntityService : ILegalEntityService
    {
        private readonly dbfirstcontext _dbc;
        public LegalEntityService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public string GetCorrespondingLegalEntity(int? id)
        {
            try
            {
                var leName = _dbc.LegalEntities
                    .Where(le => le.LegalEntityId == id)
                    .Select(le => le.LegalEntityName)
                    .FirstOrDefault();
                return leName ?? "";
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

        public List<LegalEntity> GetLegalEntities()
        {
            try
            {
                var legalEntities = _dbc.LegalEntities
                    .Where(x=>x.RecStatus == 1)
                    .Select(x => new LegalEntity
                    {
                        LegalEntityId = x.LegalEntityId,
                        LegalEntityName = x.LegalEntityName
                    })
                    .ToList();

                return legalEntities;
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

        public List<LegalEntity> GetLegalEntitiesForBusinessUnit(int buid)
        {
            try
            {
                var legalEntities = _dbc.LegalEntities
                    .Where(legalEntity => _dbc.BusinessUnits
                        .Any(businessUnit => businessUnit.LegalEntityId == legalEntity.LegalEntityId && businessUnit.BusinessUnitId == buid))
                    .Select(legalEntity => new LegalEntity
                    {
                        LegalEntityId = legalEntity.LegalEntityId,
                        LegalEntityName = legalEntity.LegalEntityName
                    })
                    .Distinct()
                    .ToList();

                return legalEntities;
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

        public List<LegalEntity> GetLegalEntitiesForIndividual(string user)
        {
            try
            {
                var result = (from capexUser in _dbc.CapexUsers
                              where capexUser.UserName == user
                              join businessUnit in _dbc.BusinessUnits on capexUser.BusinessUnitId equals businessUnit.BusinessUnitId
                              join legalEntity in _dbc.LegalEntities on businessUnit.LegalEntityId equals legalEntity.LegalEntityId
                              select new LegalEntity
                              {
                                  LegalEntityId = legalEntity.LegalEntityId,
                                  LegalEntityName = legalEntity.LegalEntityName,
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

        public LegalEntity GetLegalEntityById(int id)
        {
            try
            {
                var ent = _dbc.LegalEntities
                    .Where(x => x.LegalEntityId == id)
                    .FirstOrDefault();
                if(ent != null)
                {
                    return ent;
                }
                else
                {
                    return new LegalEntity();
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
