using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly dbfirstcontext _dbc;
        public AttachmentService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void deleteAttachmentsByCapex(int? id)
        {
            try
            {
                var attachmentsToDelete = _dbc.FkAttachmentsCapexes
                    .Where(attachmentsToDelete => attachmentsToDelete.FkAcCapexForm == id)
                    .ToList();

                _dbc.FkAttachmentsCapexes.RemoveRange(attachmentsToDelete);
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

        public List<FkAttachmentsCapex> findAttachmentsByCapex(int? id)
        {
            try
            {
                var attach = _dbc.FkAttachmentsCapexes
                    .Where(attach => attach.FkAcCapexForm == id)
                    .Select(attach => new FkAttachmentsCapex
                    {
                        FkAcAttachmentTypes = attach.FkAcAttachmentTypes,
                        FkAcFile = attach.FkAcFile,
                        FkAcPath = attach.FkAcPath,
                    })
                    .ToList();

                return attach;
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

        public string GetAttachmentName(int id)
        {
            try
            {
                var name = _dbc.AttachmentTypes
                    .Where(k => k.AttachmentId == id)
                    .Select(k => k.AttachmentName)
                    .FirstOrDefault();

                return name;
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

        public List<AttachmentType> GetAttachments()
        {
            try
            {
                return _dbc.AttachmentTypes
                    .Where(x=>x.RecStatus == 1)
                    .Select(x => new AttachmentType
                    {
                        AttachmentId = x.AttachmentId,
                        AttachmentName = x.AttachmentName,
                    })
                    .ToList();
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

        public void saveAttachments(List<FkAttachmentsCapex> attach)
        {
            try
            {
                foreach (var item in attach)
                {
                    _dbc.FkAttachmentsCapexes.Add(item);
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
    }
}
