using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class WorkRecordService : IWorkRecordService
    {
        private readonly dbfirstcontext _dbc;
        public WorkRecordService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void AddWorkRecord(EmployeeWorkRecord employeeWorkRecord)
        {
            try
            {
                EmployeeWorkRecord employee = new EmployeeWorkRecord();
                employee.BUDeptRoleID = employeeWorkRecord.BUDeptRoleID;
                employee.EmpID = employeeWorkRecord.EmpID;
                employee.ToDate = employeeWorkRecord.ToDate;
                employee.FromDate = employeeWorkRecord.FromDate;
                employee.RecStatus = employeeWorkRecord.RecStatus;

                _dbc.EmployeeWorkRecords.Add(employee);
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

        public List<AccessType> GetAccessTypes()
        {
            try
            {
                return _dbc.AccessTypes.ToList();
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

        public List<AccessType> GetAccessTypesForCapex(int roleId)
        {
            List<AccessType> accesstypes = new List<AccessType>();
            var list = _dbc.AccessLinks
                .Where(x => x.RoleID == roleId && x.ModuleID == 1)
                .Select(x => x.AccessTypeID)
                .Distinct()
                .ToList();

            foreach (var item in list)
            {
                var itemtoadd = _dbc.AccessTypes
                    .Where(x => x.AccessTypeId == item)
                    .FirstOrDefault();

                if (itemtoadd != null)
                {
                    accesstypes.Add(itemtoadd);
                }
            }

            return accesstypes;
        }

        public List<AccessType> GetAccessTypesForDiscipline(int roleId)
        {
            List<AccessType> accesstypes = new List<AccessType>();
            var list = _dbc.AccessLinks
                .Where(x => x.RoleID == roleId && x.ModuleID == 3)
                .Select(x => x.AccessTypeID)
                .Distinct()
                .ToList();

            foreach (var item in list)
            {
                var itemtoadd = _dbc.AccessTypes
                    .Where(x => x.AccessTypeId == item)
                    .FirstOrDefault();

                if (itemtoadd != null)
                {
                    accesstypes.Add(itemtoadd);
                }
            }

            return accesstypes;
        }

        public List<AccessType> GetAccessTypesForModule(int moduleId)
        {
            List<AccessType> accessTypes = new List<AccessType>();
            var list = _dbc.AccessLinks
                .Where (x => x.ModuleID == moduleId)
                .Select(x => x.AccessTypeID)
                .Distinct()
                .ToList();
            foreach(var item in list)
            {
                var at = _dbc.AccessTypes
                    .Where (x => x.AccessTypeId == item)
                    .FirstOrDefault();
                if(at != null)
                {
                    accessTypes.Add(at);
                }
            }
            return accessTypes;
        }

        public List<AccessType> GetAccessTypesforRole(int roleId)
        {
            List<AccessType> accesstypes = new List<AccessType>();
            var list = _dbc.AccessLinks
                .Where(x => x.RoleID == roleId && x.ModuleID == 2)
                .Select(x => x.AccessTypeID)
                .Distinct()
                .ToList();

            foreach (var item in list)
            {
                var itemtoadd = _dbc.AccessTypes
                    .Where(x => x.AccessTypeId == item)
                    .FirstOrDefault();

                if (itemtoadd != null)
                {
                    accesstypes.Add(itemtoadd);
                }
            }

            return accesstypes;
        }

        public List<AccessType> GetAccessTypesForYOMS(int roleId)
        {
            List<AccessType> accesstypes = new List<AccessType>();
            var list = _dbc.AccessLinks
                .Where(x => x.RoleID == roleId && x.ModuleID == 4)
                .Select(x => x.AccessTypeID)
                .Distinct()
                .ToList();

            foreach (var item in list)
            {
                var itemtoadd = _dbc.AccessTypes
                    .Where(x => x.AccessTypeId == item)
                    .FirstOrDefault();

                if (itemtoadd != null)
                {
                    accesstypes.Add(itemtoadd);
                }
            }

            return accesstypes;
        }

        public List<BusinessUnitDeptRoleLinking> GetAllBusinessUnitDeptRoleLinks()
        {
            try
            {
                var list = _dbc.BusinessUnitDeptRoleLinkings
                .Where(x => x.RecStatus == 1)
                .ToList();
                return list;
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

        public List<Modules> GetAllModules()
        {
            try
            {
                return _dbc.Modules.ToList();
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

        public List<EmployeeWorkRecord> GetAllWorkRecords()
        {
            try
            {
                var list = _dbc.EmployeeWorkRecords
                .Where(x => x.RecStatus == 1)
                .ToList();
                return list;
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

        public List<BusinessUnit> GetBusinessUnitsForLegalEntity(int legalentityID)
        {
            try
            {
                var businessunits = _dbc.BusinessUnits
                .Where(x => x.LegalEntityId == legalentityID)
                .Distinct()
                .ToList();
                return businessunits;
            }
            catch(Exception ex)
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

        public List<EmployeeDepartment> GetDepartmentsForBusnessUnit(int unitId)
        {
            List<EmployeeDepartment> employeeDepartments = new List<EmployeeDepartment>();
            var list = _dbc.AccessLinks
                .Where(x => x.BusinessUnitID == unitId)
                .Select(x => x.DepartmentID)
                .Distinct()
                .ToList();

            foreach (var item in list)
            {
                var itemtoadd = _dbc.EmployeeDepartments
                    .Where(x => x.Id == item)
                    .FirstOrDefault();
                    
                if (itemtoadd != null)
                {
                    employeeDepartments.Add(itemtoadd);
                }
            }

            return employeeDepartments;
        }

        public EmployeeWorkRecord GetEmployeeWorkRecord(int employeeId)
        {
            try
            {
                var employee = _dbc.EmployeeWorkRecords
                    .Where(x=>x.EmpID == employeeId)
                    .FirstOrDefault();
                if(employee != null)
                {
                    return employee;
                }
                else
                {
                    return null;
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

        public List<EmployeeWorkRecord> GetEmployeeWorkRecords(string employeeNum)
        {
            try
            {
                var employee = _dbc.Employees
                    .Where(x => x.EmployeeNumber == employeeNum )
                    .Select(x => x.EmployeeID)
                    .FirstOrDefault();

                if (employee != 0)
                {
                    var list = _dbc.EmployeeWorkRecords
                        .Where(x=>x.RecStatus == 1 && x.EmpID == employee && x.RecStatus == 1)
                        .Select(x=> new EmployeeWorkRecord
                        {
                            EmpID = x.EmpID,
                            RecStatus = x.RecStatus,
                            BUDeptRoleID = x.BUDeptRoleID,
                            FromDate = x.FromDate,
                            ToDate = x.ToDate,
                        })
                        .ToList();
                    return list;
                }
                else
                {
                    return new List<EmployeeWorkRecord>();
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

        public List<EmployeeWorkRecord> GetEmployeeWorkRecords(int employeeId)
        {
            try
            {
                var employee = _dbc.Employees
                    .Where(x => x.EmployeeID == employeeId)
                    .FirstOrDefault();

                if (employee != null)
                {
                    var list = _dbc.EmployeeWorkRecords
                        .Where(x => x.RecStatus == 1 && x.EmpID == employee.EmployeeID)
                        .Select(x => new EmployeeWorkRecord
                        {
                            Id = x.Id,
                            EmpID = x.EmpID,
                            RecStatus = x.RecStatus,
                            BUDeptRoleID = x.BUDeptRoleID,
                            FromDate = x.FromDate,
                            ToDate = x.ToDate,
                        })
                        .ToList();
                    return list;
                }
                else
                {
                    return new List<EmployeeWorkRecord>();
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

        public string GetLegalEntityName(int businessunitid)
        {
            var item = _dbc.BusinessUnits
                .Where(x => x.BusinessUnitId == businessunitid)
                .FirstOrDefault();
            if (item != null)
            {
                var legalentities = _dbc.LegalEntities
                    .Where(x=>x.LegalEntityId == item.LegalEntityId)
                    .FirstOrDefault ();
                if(legalentities != null)
                {
                    return legalentities.LegalEntityName;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public AccessLinking GetLinking(int id)
        {
            var item = _dbc.AccessLinks                
                .Where (x=>x.Id == id)
                .FirstOrDefault();
            if(item != null)
            {
                return item;
            }
            else
            {
                return null;
            }

        }

        public List<Modules> GetModulesForRole(int roleId)
        {
            List<Modules> modules = new List<Modules>();

            var items = _dbc.AccessLinks
                .Where(x=>x.RoleID == roleId)
                .Select(x=>x.ModuleID)
                .Distinct()
                .ToList();

            foreach(var item in items)
            {
                var itemtoadd = _dbc.Modules
                    .Where(x => x.Id == item)
                    .FirstOrDefault();
                if( itemtoadd != null)
                {
                    modules.Add (itemtoadd);
                }
            }
            return modules;
        }

        public List<Role> GetRolesForDepartment(int departmentId)
        {
            List<Role> roles = new List<Role>();
            List<EmployeeDepartment> employeeDepartments = new List<EmployeeDepartment>();

                var items = _dbc.AccessLinks
                .Where(x => x.DepartmentID == departmentId)
                .Select(x => x.RoleID)
                .Distinct()
                .ToList();
                foreach (var item in items)
                {
                    var itemtoadd = _dbc.Roles
                        .Where(x => x.RoleId == item)
                        .FirstOrDefault();
                    if (itemtoadd != null)
                    {
                        roles.Add(itemtoadd);
                    }
                }
                
            
            return roles;
        }

        public int SetEmployeeWorkRecordLegalEntity(BusinessUnitDeptRoleLinking linking)
        {
            var link = _dbc.BusinessUnitDeptRoleLinkings
                .Where(x=>x.BusinessUnitID == linking.BusinessUnitID && x.DepartmentID == linking.DepartmentID && x.RoleID == linking.RoleID)
                .FirstOrDefault();
            if (link != null)
            {
                return link.Id;
            }
            else return 0;
        }

        public void UpdateAllWorkRecordsToDate(List<EmployeeWorkRecord> records)
        {
            if(records != null)
            {
                foreach (var record in records)
                {
                    record.ToDate = DateTime.Now;
                    record.RecStatus = 1001;
                    _dbc.EmployeeWorkRecords.Update(record);
                }
                _dbc.SaveChanges();
            }            
        }
    }
}
