using YODA.Repos.Models;

namespace YODA.Services
{
    public interface ICapexFormService
    {
        bool AddUpdateCapex(CapexForm capexForm);
        bool DeleteCapex(int id);
        CapexForm FindCapexById(int id);
        List<CapexForm> GetAllCapexForms();
        List<CapexForm> GetAllCapexFormsForBusinessUnit(int businessUnit, int department);
        List<CapexForm> GetAllCapexFormsForInitiator(string initiator);
        CapexForm GetCapexFormByName(string capexname);
        List<CapexForm> GetCapexForNotSubmitted();
        List<CapexForm> GetCapexForNotSubmittedBusinessUnit(int businessUnit);
        List<CapexForm> GetCapexForNotSubmittedInitiator(string initiator);
        List<CapexForm> GetCapexForCompleted();
        List<CapexForm> GetCapexForCompletedBusinessUnit(int businessUnit, int department);
        List<CapexForm> GetCapexForCompletedInitiator(string initiator);
        List<CapexForm> GetCapexForAwaitingApproval();
        List<CapexForm> GetCapexForAwaitingApprovalBusinessUnit(int businessUnit);
        List<CapexForm> GetCapexForAwaitingApprovalInitiator(int initiator);
        List<CapexForm> GetCapexToSign(int user);
        List<CapexForm> GetCapexForApproved();
        List<CapexForm> GetCapexForApprovedBusinessUnit(int businessUnit, int department);
        List<CapexForm> GetCapexForApprovedInitiator(string initiator);
        List<CapexForm> GetCapexForOnHold();
        List<CapexForm> GetCapexForOnHoldBusinessUnit(int businessUnit, int department);
        List<CapexForm> GetCapexForOnHoldInitiator(string initiator);
        List<CapexForm> GetCapexForDeclined();
        List<CapexForm> GetCapexForDeclinedBusinessUnit(int businessUnit, int department);
        List<CapexForm> GetCapexForDeclinedInitiator(string initiator);
        List<CapexForm> GetCapexForAnalytics();
        void ChangeToModify(int id);

        string GetCorrespondingComanyName(int? id);
        string GetCorrespondingSitename(int? id);
        string GetCorrespondingLLCName(int? id);
        string GetCorrespondingBSCName(int? id);
        string GetCorrespondingACName(int? id);
        string GetCorrespondingPCName(int? id);
        string GetCorrespondingDeptName(int? id);

        void PutFormOnHold(int? id, string reason, int? userId);
        void DeclineForm(int? id, string reason, int? userId);
        void SignForm(int id, string username, string password, string reason, int userId);

        void DeleteComments(int id, List<Comment> comments);

        void SaveComments(int id, List<Comment> comments);

        void WithdrawCapex(int id);
        
        List<CapexForm> CombinedDataForAnalytics(List<LegalEntity> legalEntities, List<BusinessUnit> businessUnits, List<Employee> capexUsers, List<EmployeeDepartment> empDepartments);

        int GetCapexForm(CapexForm form);

        List<FkSignatoriesCapex> GetSignatoriesCapex(int id);

        List<CapexForm> RemoveDuplicates(List<CapexForm> forms);

        void UpdateProjectNumberEtc(int capexid, string projectnumber, int balancesheetid, int locationcostid);

        void UpdateDateOfPaymentForCapex(int capexid, DateTime date);

        List<CapexForm> GetCapexFormsWhereAllHaveSigned();

        List<CapexForm> GetCapexWhereCapexTitleHas(string word);
    }
}
