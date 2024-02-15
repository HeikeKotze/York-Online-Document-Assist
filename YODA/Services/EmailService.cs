using Blazorise.DataGrid;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Diagnostics;
using System.Net.Mail;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class EmailService : IEmailService
    {
        private readonly dbfirstcontext _dbc;
        public EmailService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        

        public string GetEmailMessage(int id)
        {
            try
            {
                var message = _dbc.MailMessages
                    .Where (x => x.Id == id)
                    .FirstOrDefault ();
                return message.MessageToMail;
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

        public void SendMail(string emailaddress, string messagebody, int capexnum)
        {
            using(SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using(MailMessage message = new MailMessage(emailaddress, emailaddress
                    , $"Capex Created - YRK_Capex_{capexnum}", messagebody)) 
                {
                    MailAddress fromAddress = new MailAddress(emailaddress);
                    MailAddress toAddress = new MailAddress(emailaddress);

                    smtpClient.Send(message);
                }
            }
        }

        public void SendMailToSignatory(string fromemail, string toemail, string messagebody, int capexnum)
        {
            using(SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using(MailMessage message = new MailMessage(fromemail,toemail
                    , $"Capex Sign - YRK_Capex_{capexnum}", messagebody))
                {
                    MailAddress fromAddress = new MailAddress (fromemail);
                    MailAddress toAddress = new MailAddress(toemail);

                    smtpClient.Send(message);
                }
            }
        }

        public void SignConfirmationEmail(string email, string messagebody, int capexnum)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(email, email
                    , $"Capex Sign - YRK_Capex_{capexnum}", messagebody))
                {
                    MailAddress fromAddress = new MailAddress(email);
                    MailAddress toAddress = new MailAddress(email);

                    smtpClient.Send(message);
                }
            }
        }

        public void FullySignedEmail(string email, string messagebody, int capexnum)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(email, email
                    , $"Capex Sign - YRK_Capex_{capexnum}", messagebody))
                {
                    MailAddress fromAddress = new MailAddress(email);
                    MailAddress toAddress = new MailAddress(email);

                    smtpClient.Send(message);
                }
            }
        }

        public void SendMailToDisciplineOriginator(string fromemail, string toemail, string messagebody, int userdiscipline)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(fromemail, toemail
                    , $"Comment left for Discipline # - {userdiscipline}", messagebody))
                {
                    MailAddress fromAddress = new MailAddress(fromemail);
                    MailAddress toAddress = new MailAddress(toemail);

                    smtpClient.Send(message);
                }
            }
        }

        public void SendCapexNumberToInitiator(string fromemail, string toemail, string messagebody, int capexnum)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(fromemail, toemail
                    , $"Capex Sign - YRK_Capex_{capexnum}", messagebody))
                {
                    MailAddress fromAddress = new MailAddress(fromemail);
                    MailAddress toAddress = new MailAddress(toemail);

                    smtpClient.Send(message);
                }
            }
        }

        public void SendEmailToRequestProjectNumber(string fromemail, string toemail, string messagebody, int capexnum)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(fromemail, toemail
                    , $"Capex Sign - YRK_Capex_{capexnum}", messagebody))
                {
                    MailAddress fromAddress = new MailAddress(fromemail);
                    MailAddress toAddress = new MailAddress(toemail);

                    smtpClient.Send(message);
                }
            }
        }

        public void SendEmailToYODAAdmin(string fromemail, string toemail, string messagebody, string name)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(fromemail, toemail
                    , $"YODA Question From {name}", messagebody))
                {
                    MailAddress fromAddress = new MailAddress(fromemail);
                    MailAddress toAddress = new MailAddress(toemail);

                    smtpClient.Send(message);
                }
            }
        }

        public void SaveEmailMessageToAdmin(MessageToAdmin message)
        {
            if(message.Id == 0 || message.Id == null)
            {
                _dbc.MessagesToAdmin.Add(message);
                _dbc.SaveChanges();
            }
            else
            {
                _dbc.MessagesToAdmin.Update(message);
                _dbc.SaveChanges();
            }
            
        }

        public List<MessageToAdmin> GetAllMessages()
        {
            return _dbc.MessagesToAdmin.ToList();
        }

        public void SendEmailToSender(string fromemail, string toemail, string messagetosend)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(fromemail, toemail
                    , $"York Online Document Assist Reply", messagetosend))
                {
                    MailAddress fromAddress = new MailAddress(fromemail);
                    MailAddress toAddress = new MailAddress(toemail);

                    smtpClient.Send(message);
                }
            }
        }

        public void SendEmailForPasswordRequest(string email, string messagebody)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(email, email
                    , "Password Reset Request", messagebody))
                {
                    MailAddress fromAddress = new MailAddress(email);
                    MailAddress toAddress = new MailAddress(email);

                    smtpClient.Send(message);
                }
            }
        }

        public void SendEmailToHRAfterDisciplineApprove(string fromemail, string toemail, string messagetosend)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(fromemail, toemail
                    , $"Employee Discipline Submitted", messagetosend))
                {
                    MailAddress fromAddress = new MailAddress(fromemail);
                    MailAddress toAddress = new MailAddress(toemail);

                    smtpClient.Send(message);
                }
            }
        }

        public void SendEmailForAppeal(string fromemail, string toemail, string messagetosend, int disciplineid)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "172.16.28.50";

                using (MailMessage message = new MailMessage(fromemail, toemail
                    , $"York Employee Conduct Appeal Created for Discipline #{disciplineid}", messagetosend))
                {
                    MailAddress fromAddress = new MailAddress(fromemail);
                    MailAddress toAddress = new MailAddress(toemail);

                    smtpClient.Send(message);
                }
            }
        }
    }
}
