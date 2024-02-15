using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IEmailService
    {
        void SendMail(string emailaddress, string messagebody, int capexnum);

        void SendMailToSignatory(string fromemail, string toemail, string messagebody, int capexnum);

        void SignConfirmationEmail(string email, string messagebody, int capexnum);
        void SendMailToDisciplineOriginator(string fromemail, string toemail, string messagebody, int userdiscipline);
        void FullySignedEmail(string email, string messagebody, int capexnum);

        string GetEmailMessage(int id);

        void SendCapexNumberToInitiator(string fromemail, string toemail, string messagebody, int capexnum);
        void SendEmailToRequestProjectNumber(string fromemail, string toemail, string messagebody, int capexnum);

        void SendEmailToYODAAdmin(string fromemail, string toemail, string messagebody, string name);

        void SaveEmailMessageToAdmin(MessageToAdmin message);

        List<MessageToAdmin> GetAllMessages();

        void SendEmailToSender(string fromemail, string toemail, string messagetosend);
        void SendEmailForPasswordRequest(string email, string messagebody);

        void SendEmailToHRAfterDisciplineApprove(string fromemail, string toemail, string messagetosend);

        void SendEmailForAppeal(string fromemail, string toemail, string messagetosend, int disciplineid);

    }
}
