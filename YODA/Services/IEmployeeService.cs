using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IEmployeeService
    {
        void AddUpdateEmployee(Employee employee);
        void AddCapexUser(CapexUser user);
        List<Employee> GetAll();

        List<Employee> GetEmployees();
        Employee GetById(int id);
        int GetEmpID(Employee employee);
        List<LanguageProficiency> GetLanguages(int id);
        List<Dependants> GetDependants(int id);
        List<Beneficiaries> GetBeneficiaries(int id);
        List<PreviousEmployment> GetPreviousEmployments(int id);
        List<EducationalHistory> GetEducationalHistory(int id);
        List<LicenceCodes> GetLicenceCodes(int id);
        void SaveLanguageProficiency(List<LanguageProficiency> languages);
        void SaveDependants(List<Dependants> dependants);
        void SaveBeneficiaries(List<Beneficiaries> beneficiaries);
        void SavePreviousEmployment(List<PreviousEmployment> previousEmployments);
        void SaveEducationalHistory(List<EducationalHistory> history);
        void SaveLicenceCodes(List<LicenceCodes> licenceCodes);
        void DeleteLanguageProficiency(int id);
        void DeleteDependants(int id);
        void DeleteBeneficiaries(int id);
        void DeletePreviousEmployment(int id);
        void DeleteEducationalHistory(int id);
        void DeleteLicenceCodes(int id);
        List<EmployeeTitle> GetEmployeeTitles();
        List<EmployeeGender> GetEmployeeGenders();
        List<EmployeeLanguage> GetEmployeeLanguages();
        List<EmployeeRace> GetEmployeeRaces();
        List<EmployeeMaritalStatus> GetEmployeeMaritalStatuses();
        List<EmployeePayPeriod> GetEmployeePayPeriods();
        List<EmployeePayMethod> GetEmployeePayMethods();
        List<EmployeeUnion> GetEmployeeUnions();
        List<EmployeeDepartment> GetEmployeeDepartments();
        List<EmployeeJobGrade> GetEmployeeJobGrades();
        List<DrivingCodes> GetDrivingCodes();
        List<EmployeeNationality> GetEmployeeNationalities();

        string GetCorrespondingLanguage(int? id);
        string GetCorrespondingTitle(int? id);
        string GetCorrespondingGender(int? id);
        string GetCorrespondingRace (int? id);
        string GetCorrespondingNationality(int? id);
        string GetCorrespondingPayPeriod (int? id);
        string GetCorrespondingDepartment (int? id);
        string GetCorrespondingPayMethod (int? id);
        string GetCorrespondingJobGrade (int? id);
        string GetCorrespondingUnion (int? id);
        string GetCorrespondingMaritalStatus (int? id);
        string GetCorrespondingLicenceCode (int? id);

        List<Employee> GetEmployee(int id);
        List<Employee> DepartmentListofEmployees(int id);
        List<Employee> GetEmployee(string empnumber);

        Employee GetSingleEmployee(string empnumber);

        bool existingEmployeeNumber(string num);

        string GetEmployeeName(string id);

        List<EmployeeDepartment> GetDepartmentList();
        EmployeeDepartment GetDepartment(int id);
        BusinessUnit GetBusinessUnit(int id);

        List<Employee> GetEmployeesforBusinessUnitDepartment(int buid, int deptid);

        void CeaseEmployee(int empid);
        void RemoveEmployeeWorkRecords(int empid);
        CapexUser GetCapexUser(string empnumber);

        List<InterestStatus> GetInterestStatusList();

    }
}
