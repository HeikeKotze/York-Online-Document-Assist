using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IWorkRecordService
    {
        List<EmployeeWorkRecord> GetAllWorkRecords();

        AccessLinking GetLinking(int id);
        List<BusinessUnitDeptRoleLinking> GetAllBusinessUnitDeptRoleLinks();
        EmployeeWorkRecord GetEmployeeWorkRecord(int employeeId);
        List<BusinessUnit> GetBusinessUnitsForLegalEntity(int legalentityID);
        List<EmployeeDepartment> GetDepartmentsForBusnessUnit(int unitId);
        List<Role> GetRolesForDepartment(int departmentId);
        List<AccessType> GetAccessTypesforRole(int roleId);
        int SetEmployeeWorkRecordLegalEntity(BusinessUnitDeptRoleLinking linking);
        void AddWorkRecord(EmployeeWorkRecord employeeWorkRecord);
        List<EmployeeWorkRecord> GetEmployeeWorkRecords(string employeeNum);
        List<EmployeeWorkRecord> GetEmployeeWorkRecords(int employeeId);
        List<AccessType> GetAccessTypesForCapex(int roleId);
        List<AccessType> GetAccessTypesForDiscipline(int roleId);
        List<AccessType> GetAccessTypesForYOMS(int roleId);
        List<Modules> GetModulesForRole(int roleId);
        List<AccessType> GetAccessTypesForModule(int moduleId);
        List<AccessType> GetAccessTypes();
        List<Modules> GetAllModules();
        string GetLegalEntityName(int businessunitid);
        void UpdateAllWorkRecordsToDate(List<EmployeeWorkRecord> records);
    }
}
