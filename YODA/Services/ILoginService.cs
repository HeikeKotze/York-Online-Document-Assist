using DocumentFormat.OpenXml.VariantTypes;
using YODA.Repos.Models;

namespace YODA.Services
{
    public interface ILoginService
    {
        public CapexUser LoginConfirmation(string username, string password, bool success);
        public void ChangePassword(int id, string password);
        public bool checkIfPasswordExists(string password);

        public bool checkEmailAddressAndEmployeeNumberMatch(string empnumber, string email);

        public void AddRequestPassword(RequestPassword qp);
        public bool CheckRequestCodeAndEmpNumber(string code, int empid);
        public void UpdateRequestPassword(string code, int empid);
        public void ChangePasswordFromRequest(string username, string password);

        public void DeleteRequestPassword(int id);
        public RequestPassword GetRequestPassword(string code, int empid);
        public bool checkedRequestForExpiryDate(RequestPassword qp);
    }
}
