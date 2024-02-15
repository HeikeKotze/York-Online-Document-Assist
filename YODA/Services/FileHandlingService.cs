using Blazorise.DataGrid;
using System.Diagnostics;
using System.Net.Mail;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class FileHandlingService : IFileHandlingService
    {
        private readonly dbfirstcontext _dbc;
        public FileHandlingService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void AddLinkedDocuments(List<LinkedDocuments> linkedDocuments)
        {
            foreach (LinkedDocuments linkedDocument in linkedDocuments)
            {
                var newLinkedDoc = new LinkedDocuments
                {
                    FileTypeID = linkedDocument.FileTypeID,
                    DescriptionOther = linkedDocument.DescriptionOther,
                    FullFileName = linkedDocument.FullFileName,
                    OffenceBreachID = linkedDocument.OffenceBreachID,
                    RecStatus = linkedDocument.RecStatus,
                };
                _dbc.LinkedDocuments.Add(newLinkedDoc);
            }
            _dbc.SaveChanges();
        }

        public List<FileTypes> GetAllFileTypes()
        {
            try
            {
                return _dbc.FileTypes.Where(x=>x.PrePostDisciplinary == 2).ToList();
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

        public List<FileTypes> GetFileTypesPreDiscipline()
        {
            return _dbc.FileTypes.Where(x => x.PrePostDisciplinary == 1).ToList();
        }
    }
}
