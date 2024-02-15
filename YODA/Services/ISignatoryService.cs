
using YODA.Repos.Models;
namespace YODA.Services
{
    public interface ISignatoryService
    {
        public void deleteSignatoriesByCapex(int? id);
        public List<FkSignatoriesCapex> findSignatoriesByCapex(int? id);
        public void saveSignatories(List<FkSignatoriesCapex> signatories);

        public int GetCorrespondingRoleId(string name);
        public string GetCorrespondingRoleName(string name);

        public string? GetUserName(int? userId);
        public string? GetRoleName(int? roleId);
        public bool BoardInSignatories(List<FkSignatoriesCapex> list);

        public int GetRoleID(int id);
        public string GetRoleName(int roleId);
        public int RetrieveRoleID(string name);

        public int RetrieveEmpID(string name);
        public string RetrieveRoleName(string name);
        public string RetrieveEmpName(int sigid);

        public string RetrieveEmpNum(string name);

        int returnCEOCFOEmployeeID(int roleid);
    }
}
