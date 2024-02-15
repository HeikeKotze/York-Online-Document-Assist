using System.Diagnostics;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class CommentService : ICommentService
    {
        private readonly dbfirstcontext _dbc;
        public CommentService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public bool CommentsInList(List<Comment> comments)
        {
            return comments != null && comments.Any();
        }

        public List<Comment> GetComments(int id)
        {
            try
            {
                var comments = _dbc.Comments
                    .Where(c => c.FkCapexId == id)
                    .Select(c => new Comment
                    {
                        FormSection = c.FormSection,
                        Consentee = c.Consentee,
                        Comments = c.Comments
                    })
                    .ToList();

                return comments;
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
