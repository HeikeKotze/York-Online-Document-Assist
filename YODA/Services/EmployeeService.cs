using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YODA.Pages.CapexComponents;
using YODA.Repos;
using YODA.Repos.Models;
using YODA.Services;

namespace YODA.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly dbfirstcontext _dbc;
        public EmployeeService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void AddUpdateEmployee(Employee employee)
        {
            try
            {
                if (employee.EmployeeID == 0)
                {
                    _dbc.Employees.Add(employee);
                }
                else
                {
                    _dbc.Employees.Update(employee);
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

        public int GetEmployeeID(Employee employee)
        {
            var emp = _dbc.Employees.FirstOrDefault(emp => emp.EmployeeID == employee.EmployeeID);
            return emp != null ? emp.EmployeeID : 0;
        }

        public void DeleteBeneficiaries(int id)
        {
            try
            {
                var beneficiariesdelete = _dbc.Beneficiaries
                    .Where(ben => ben.EmployeeID == id)
                    .ToList();

                _dbc.Beneficiaries.RemoveRange(beneficiariesdelete);
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

        public void DeleteDependants(int id)
        {
            try
            {
                var dependantsdelete = _dbc.Dependants
                    .Where(dep => dep.EmployeeID == id)
                    .ToList();
                _dbc.Dependants.RemoveRange(dependantsdelete);
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

        public void DeleteEducationalHistory(int id)
        {
            try
            {
                var educationdelete = _dbc.EducationalHistories
                    .Where(edu=>edu.EmployeeID == id)
                    .ToList();
                _dbc.EducationalHistories.RemoveRange(educationdelete);
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

        public void DeleteLanguageProficiency(int id)
        {
            try
            {
                var languagedelete = _dbc.LanguageProficiencies
                    .Where(lang=> lang.EmployeeID == id)
                    .ToList();
                _dbc.LanguageProficiencies.RemoveRange(languagedelete);
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

        public void DeletePreviousEmployment(int id)
        {
            try
            {
                var employmentdelete = _dbc.PreviousEmployments
                    .Where(emp=>emp.EmployeeID == id)
                    .ToList();
                _dbc.PreviousEmployments.RemoveRange(employmentdelete);
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

        public List<Employee> GetAll()
        {
            try
            {
                var employees = _dbc.Employees
                    .Select(emp=> new Employee
                    {
                        EmployeeID = emp.EmployeeID,
                        EmployeeNumber = emp.EmployeeNumber,
                        FirstName = emp.FirstName,
                        Surname = emp.Surname,
                        FullName = emp.FullName,
                        DepartmentID = emp.DepartmentID,
                    })
                    .ToList();
                return employees;
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

        public List<Beneficiaries> GetBeneficiaries(int id)
        {
            try
            {
                var beneficiaries = _dbc.Beneficiaries
                    .Where(x=>x.EmployeeID == id)
                    .Select(x=>new Beneficiaries
                    {
                        EmployeeID = x.EmployeeID,
                        FullName = x.FullName,
                        PercentageOfBenefit = x.PercentageOfBenefit,
                        DateOfBirth = x.DateOfBirth,
                        Relationship = x.Relationship,
                    })
                    .ToList();
                return beneficiaries;
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

        public Employee GetById(int id)
        {
            try
            {
                return _dbc.Employees.Find(id);

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

        public List<Dependants> GetDependants(int id)
        {
            try
            {
                var dependants = _dbc.Dependants
                .Where(x => x.EmployeeID == id)
                .Select(x => new Dependants
                {
                    Id = x.Id,
                    EmployeeID = x.EmployeeID,
                    Surname = x.Surname,
                    Name = x.Name,
                    Relationship = x.Relationship,
                    Gender = x.Gender,
                    DateOfBirth = x.DateOfBirth
                })
                .ToList();
                return dependants;
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

        public List<EducationalHistory> GetEducationalHistory(int id)
        {
            try
            {
                var education = _dbc.EducationalHistories
                    .Where(x => x.EmployeeID == id)
                    .Select(x => new EducationalHistory
                    {
                        Id = x.Id,
                        EmployeeID = x.EmployeeID,
                        PlaceOfStudy = x.PlaceOfStudy,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        Subjects = x.Subjects,
                        Qualification = x.Qualification,
                    })
                    .ToList();
                return education;
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

        public int GetEmpID(Employee employee)
        {
            try
            {
                var foundEmployee = _dbc.Employees.FirstOrDefault(x=>x.EmployeeID == employee.EmployeeID);
                if (foundEmployee != null)
                {
                    return foundEmployee.EmployeeID;
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

        public List<LanguageProficiency> GetLanguages(int id)
        {
            try
            {
                var languages = _dbc.LanguageProficiencies
                    .Where(x => x.EmployeeID == id)
                    .Select(x => new LanguageProficiency
                    {
                        Id = x.Id,
                        EmployeeID= x.EmployeeID,
                        LanguageID = x.LanguageID,
                        Speak = x.Speak,
                        Read = x.Read,
                        Write = x.Write,
                    })
                    .ToList();
                return languages;
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

        public List<PreviousEmployment> GetPreviousEmployments(int id)
        {
            try
            {
                var employments = _dbc.PreviousEmployments
                    .Where(x => x.EmployeeID == id)
                    .Select(x => new PreviousEmployment
                    {
                        Id= x.Id,
                        EmployeeID= x.EmployeeID,
                        Employer = x.Employer,
                        DateStart = x.DateStart,
                        DateEnd = x.DateEnd,
                        JobTitle = x.JobTitle,
                        Salary = x.Salary,
                        ReasonLeaving = x.ReasonLeaving,
                    })
                    .ToList();
                return employments;
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


        public void SaveBeneficiaries(List<Beneficiaries> beneficiaries)
        {
            try
            {
                foreach(var item in beneficiaries)
                {
                    _dbc.Beneficiaries.Add(item);
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

        public void SaveDependants(List<Dependants> dependants)
        {
            try
            {
                foreach(var item in dependants)
                {
                    _dbc.Dependants.Add(item);
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

        public void SaveEducationalHistory(List<EducationalHistory> history)
        {
            try
            {
                foreach(var item in history)
                {
                    _dbc.EducationalHistories.Add(item);
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

        public void SaveLanguageProficiency(List<LanguageProficiency> languages)
        {
            try
            {
                foreach(var item in languages)
                {
                    _dbc.LanguageProficiencies.Add(item);
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

        public void SavePreviousEmployment(List<PreviousEmployment> previousEmployments)
        {
            try
            {
                foreach(var item in previousEmployments)
                {
                    _dbc.PreviousEmployments.Add(item);
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

        public List<EmployeeTitle> GetEmployeeTitles()
        {
            try
            {
                var employeeTitles = _dbc.EmployeeTitles
                    .Select(x=> new EmployeeTitle
                    {
                        TitleName = x.TitleName,
                        Id = x.Id,
                        RecStatus = x.RecStatus,
                    })
                    .ToList();
                return employeeTitles;
                
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

        public List<EmployeeGender> GetEmployeeGenders()
        {
            try
            {
                var employeeGenders = _dbc.EmployeeGenders
                    .Select(x=> new EmployeeGender
                    {
                        Id = x.Id,
                        GenderName = x.GenderName,
                        RecStatus= x.RecStatus,
                    })
                    .ToList();
                return employeeGenders;
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

        public List<EmployeeLanguage> GetEmployeeLanguages()
        {
            try
            {
                var employeeLanguages = _dbc.EmployeeLanguages
                    .Select(x => new EmployeeLanguage
                    {
                        Id = x.Id,
                        LanguageName = x.LanguageName,
                        RecStatus = x.RecStatus,
                    })
                    .ToList();
                return employeeLanguages;
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

        public List<EmployeeRace> GetEmployeeRaces()
        {
            try
            {
                var employeeRaces = _dbc.EmployeeRaces
                    .Select(x=>new EmployeeRace
                    {
                        Id=x.Id,
                        RaceName = x.RaceName,
                        RecStatus=x.RecStatus,
                    })
                    .ToList();
                return employeeRaces;
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

        public List<EmployeeMaritalStatus> GetEmployeeMaritalStatuses()
        {
            try
            {
                var employeemarital = _dbc.EmployeeMaritalStatuses
                    .Select(x=> new EmployeeMaritalStatus
                    {
                        Id = x.Id,
                        MaritalStatusName = x.MaritalStatusName,
                        RecStatus = x.RecStatus,
                    })
                    .ToList();
                return employeemarital;
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

        public List<EmployeePayPeriod> GetEmployeePayPeriods()
        {
            try
            {
                var employeePayPeriods = _dbc.EmployeePayPeriods
                    .Select(x=> new EmployeePayPeriod
                    {
                        Id=x.Id,
                        PayPeriodName = x.PayPeriodName,
                        RecStatus=x.RecStatus,
                    })
                    .ToList();
                return employeePayPeriods;
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

        public List<EmployeePayMethod> GetEmployeePayMethods()
        {
            try
            {
                var employeePayMethods = _dbc.EmployeePayMethods
                    .Select(x=> new EmployeePayMethod
                    {
                        Id=x.Id,
                        PayMethodName = x.PayMethodName,
                        RecStatus = x.RecStatus,
                    })
                    .ToList();
                return employeePayMethods;
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

        public List<EmployeeUnion> GetEmployeeUnions()
        {
            try
            {
                var employeeUnions = _dbc.EmployeeUnions
                    .Select(x => new EmployeeUnion
                    {
                        Id = x.Id,
                        UnionName = x.UnionName,
                        RecStatus = x.RecStatus,
                    })
                    .ToList();
                return employeeUnions;
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

        public List<EmployeeDepartment> GetEmployeeDepartments()
        {
            try
            {
                var empDept = _dbc.EmployeeDepartments
                    .Select(x => new EmployeeDepartment
                    {
                        Id = x.Id,
                        DepartmentName = x.DepartmentName,
                        RecStatus= x.RecStatus,
                    })
                    .ToList();
                return empDept;
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

        public List<EmployeeJobGrade> GetEmployeeJobGrades()
        {
            try
            {
                var empJG = _dbc.EmployeeJobGrades
                    .Select(x=>new EmployeeJobGrade
                    {
                        Id = x.Id,
                        JobGradeName = x.JobGradeName,
                        RecStatus = x.RecStatus,
                    })
                    .ToList();
                return empJG;
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

        public List<LicenceCodes> GetLicenceCodes(int id)
        {
            try
            {
                var licenceCodes = _dbc.LicenceCodes
                    .Where(x=>x.EmployeeID == id)
                    .Select(x=> new LicenceCodes
                    {
                        Id= x.Id,
                        EmployeeID = x.EmployeeID,
                        LicenceCodeID = x.LicenceCodeID,
                    })
                    .ToList();
                return licenceCodes;
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

        public void SaveLicenceCodes(List<LicenceCodes> licenceCodes)
        {
            try
            {
                foreach (var item in licenceCodes)
                {
                    _dbc.LicenceCodes.Add(item);
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

        public void DeleteLicenceCodes(int id)
        {
            try
            {
                var licencecodesToDelete = _dbc.LicenceCodes
                    .Where(lic => lic.EmployeeID == id)
                    .ToList();

                _dbc.LicenceCodes.RemoveRange(licencecodesToDelete);
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

        public List<DrivingCodes> GetDrivingCodes()
        {
            try
            {
                var drivingCodes = _dbc.DrivingCodes
                    .Select(x=> new DrivingCodes
                    {
                        Id = x.Id,
                        LicenceCodeName = x.LicenceCodeName,
                        RecStatus = x.RecStatus,
                    })
                    .ToList();
                return drivingCodes;
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

        public List<EmployeeNationality> GetEmployeeNationalities()
        {
            try
            {
                var nationalities = _dbc.EmployeeNationalities
                    .Select(x => new EmployeeNationality
                    {
                        Id = x.Id,
                        NationalityName = x.NationalityName,
                        RecStatus = x.RecStatus,
                    })
                    .ToList();
                return nationalities;
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

        public string GetCorrespondingLanguage(int? id)
        {
            try
            {
                var lName = _dbc.EmployeeLanguages
                    .Where(l => l.Id == id)
                    .Select(l => l.LanguageName)
                    .FirstOrDefault();
                return lName ?? "";
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

        public string GetCorrespondingTitle(int? id)
        {
            try
            {
                var tName = _dbc.EmployeeTitles
                    .Where(t => t.Id == id)
                    .Select(t => t.TitleName)
                    .FirstOrDefault();
                return tName ?? "";
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

        public string GetCorrespondingGender(int? id)
        {
            try
            {
                var gName = _dbc.EmployeeGenders
                    .Where(g => g.Id == id)
                    .Select(g => g.GenderName)
                    .FirstOrDefault();
                return gName ?? "";
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

        public string GetCorrespondingRace(int? id)
        {
            try
            {
                var rName = _dbc.EmployeeRaces
                    .Where(r => r.Id == id)
                    .Select(r => r.RaceName)
                    .FirstOrDefault();
                return rName ?? "";
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

        public string GetCorrespondingNationality(int? id)
        {
            try
            {
                var nName = _dbc.EmployeeNationalities
                    .Where(n => n.Id == id)
                    .Select (n => n.NationalityName)
                    .FirstOrDefault();
                return nName ?? "";
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

        public string GetCorrespondingPayPeriod(int? id)
        {
            try
            {
                var ppName = _dbc.EmployeePayPeriods
                    .Where(pp => pp.Id == id)
                    .Select(pp => pp.PayPeriodName)
                    .FirstOrDefault();
                return ppName ?? "";
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

        public string GetCorrespondingDepartment(int? id)
        {
            try
            {
                var dName = _dbc.EmployeeDepartments
                    .Where(d => d.Id == id)
                    .Select(d => d.DepartmentName)
                    .FirstOrDefault();
                return dName ?? "";
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

        public string GetCorrespondingPayMethod(int? id)
        {
            try
            {
                var pmName = _dbc.EmployeePayMethods
                    .Where(pm => pm.Id == id)
                    .Select(pm => pm.PayMethodName)
                    .FirstOrDefault();
                return pmName ?? "";
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

        public string GetCorrespondingJobGrade(int? id)
        {
            try
            {
                var jgName = _dbc.EmployeeJobGrades
                    .Where(jg => jg.Id == id)
                    .Select(jg => jg.JobGradeName)
                    .FirstOrDefault();
                return jgName ?? "";
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

        public string GetCorrespondingUnion(int? id)
        {
            try
            {
                var uName = _dbc.EmployeeUnions
                    .Where(u => u.Id == id)
                    .Select(u => u.UnionName)
                    .FirstOrDefault();
                return uName ?? "";
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

        public string GetCorrespondingMaritalStatus(int? id)
        {
            try
            {
                var msName = _dbc.EmployeeMaritalStatuses
                    .Where(ms => ms.Id == id)
                    .Select(ms => ms.MaritalStatusName)
                    .FirstOrDefault();
                return msName ?? "";
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

        public string GetCorrespondingLicenceCode(int? id)
        {
            try
            {
                var lcName = _dbc.DrivingCodes
                    .Where(lc => lc.Id == id)
                    .Select(lc => lc.LicenceCodeName)
                    .FirstOrDefault();
                return lcName ?? "";
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

        public void AddCapexUser(CapexUser user)
        {
            short RecStatus = 1;
            short Lock = 1;
            try
            {
                var existingUser = _dbc.CapexUsers.FirstOrDefault(cu => cu.UserId == user.UserId);

                if (existingUser != null)
                {
                    // Update the existing Capex user
                    existingUser.UserName = user.UserName;
                    existingUser.BusinessUnitId = user.BusinessUnitId;
                    existingUser.RoleId = user.RoleId;
                    existingUser.RecStatus = RecStatus;

                    _dbc.CapexUsers.Update(existingUser);
                }
                else
                {
                    // Add a new Capex user if they don't exist
                    user.RecStatus = RecStatus;
                    _dbc.CapexUsers.Add(user);
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

        public List<Employee> GetEmployee(int id)
        {
            try
            {
                var employee = _dbc.Employees
                .Where(x => x.EmployeeID == id)
                .ToList();
                return employee;
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

        public List<Employee> DepartmentListofEmployees(int id)
        {
            try
            {
                var employees = _dbc.Employees
                .Where(x => x.DepartmentID == id)
                .ToList();
                return employees;
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

        public bool existingEmployeeNumber(string num)
        {
            var item = _dbc.Employees
                .Where(x => x.EmployeeNumber == num)
                .FirstOrDefault();
            if(item == null)
                return false;
            return true;
        }

        public string GetEmployeeName(string id)
        {
            try
            {
                var emp = _dbc.Employees
                    .Where(x=>x.EmployeeNumber == id)
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

        public List<Employee> GetEmployee(string empnumber)
        {
            var user = _dbc.Employees
                .Where(x => x.EmployeeNumber == empnumber)
                .ToList();
            return user;
        }

        public Employee GetSingleEmployee(string empnumber)
        {
            var user = _dbc.Employees
                .Where(x => x.EmployeeNumber == empnumber)
                .Select(x => new Employee
                {
                    EmployeeID = x.EmployeeID,
                    EmployeeNumber = x.EmployeeNumber,
                    FullName = x.FullName,
                    EmailAddress = x.EmailAddress,
                    CompanyNumberID = x.CompanyNumberID,
                    DepartmentID = x.DepartmentID,
                })
                .FirstOrDefault();

            if(user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<EmployeeDepartment> GetDepartmentList()
        {
            try
            {
                var list = _dbc.EmployeeDepartments
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

        public EmployeeDepartment GetDepartment(int id)
        {
            try
            {
                var item = _dbc.EmployeeDepartments
                    .Where(x=>x.Id == id)
                    .Select(x=> new EmployeeDepartment
                    {
                        Id = x.Id,
                        DepartmentName = x.DepartmentName
                    })
                    .Distinct()
                    .FirstOrDefault();
                if (item != null)
                {
                    return item;
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


        public BusinessUnit GetBusinessUnit(int id)
        {
            try
            {
                var bu = _dbc.BusinessUnits
                        .Where(x => x.BusinessUnitId == id)
                        .FirstOrDefault();
                if (bu != null)
                {
                    return bu;
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

        public List<Employee> GetEmployeesforBusinessUnitDepartment(int buid, int deptid)
        {
            try
            {

                List<Employee> employees = new();

                var capexUsers = _dbc.CapexUsers
                    .Where(x => x.BusinessUnitId == buid)
                    .ToList();
                foreach (var user in capexUsers)
                {
                    employees = _dbc.Employees
                        .Where(x => x.DepartmentID == deptid)
                        .ToList();
                }
                return employees;
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

        public void CeaseEmployee(int empid)
        {
            try
            {
                //get employee
                var employee = _dbc.Employees.Where(x => x.EmployeeID == empid).FirstOrDefault();
                if(employee != null)
                {
                    employee.RecStatus = 1001;
                    _dbc.Employees.Update(employee);
                    _dbc.SaveChanges();
                }
                else
                {
                    _dbc.SaveChanges(false);
                }

                //get employee work records
                var records = _dbc.EmployeeWorkRecords
                    .Where(x=>x.EmpID == empid)
                    .ToList();
                if(records != null)
                {
                    foreach (var item in records)
                    {
                        item.RecStatus = 1001;
                        _dbc.EmployeeWorkRecords.Update(item);
                    }
                    _dbc.SaveChanges();
                }
                else
                {
                    _dbc.SaveChanges(false);
                }
                             
                //get YODA user
                var user = _dbc.CapexUsers
                    .Where(x=>x.UserName == employee.EmployeeNumber)
                    .FirstOrDefault();
                if (user != null)
                {
                    user.RecStatus = 1001;
                    _dbc.CapexUsers.Update(user);
                    _dbc.SaveChanges();
                }
                else
                {
                    _dbc.SaveChanges(false);
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

        public void RemoveEmployeeWorkRecords(int empid)
        {
            try
            {
                var currentworkrecords = _dbc.EmployeeWorkRecords
                    .Where(x=>x.EmpID == empid)
                    .ToList();
                foreach (var item in currentworkrecords)
                {
                    item.RecStatus = 1001;
                    _dbc.EmployeeWorkRecords .Update(item);
                }
                _dbc.SaveChanges();
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

        public CapexUser GetCapexUser(string empnumber)
        {
            return _dbc.CapexUsers.Where(x=>x.UserName == empnumber).FirstOrDefault();
        }

        public List<Employee> GetEmployees()
        {
            return _dbc.Employees.ToList();
        }

        public List<InterestStatus> GetInterestStatusList()
        {
            return _dbc.InterestStatuses.Where(x => x.RecStatus == 1).ToList();
        }

        #region not used
        //public List<Employee> EmployeesDepartmentFilter(int businessunitID, int deptID)
        //{
        //    IEmployeeService employeeService = null;
        //    Employee employee = new() ;
        //    List<Employee> Employees = new();
        //    var unit = _dbc.BusinessUnits
        //        .Where(x=>x.BusinessUnitId==businessunitID)
        //        .FirstOrDefault();
        //    var department = _dbc.EmployeeDepartments
        //        .Where(x=>x.Id==deptID)
        //        .FirstOrDefault();
        //    var emps = _dbc.Employees
        //        .Where(x=>x.DepartmentID == deptID) 
        //        .FirstOrDefault();
        //    if(unit != null && emps != null)
        //    {
        //        var users = _dbc.CapexUsers
        //            .Where(x=>x.BusinessUnitId == unit.BusinessUnitId)
        //            .ToList();
        //        foreach ( var user in users )
        //        {
        //            if(user != null)
        //            {
        //                employee = employeeService.GetSingleEmployee(user.UserName);
        //            }
        //            Employees.Add( employee );
        //        }
        //        return Employees;

        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        #endregion

    }
}
