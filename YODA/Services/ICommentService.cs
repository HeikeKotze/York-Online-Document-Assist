using YODA.Repos.Models;

namespace YODA.Services
{
    public interface ICommentService
    {
        List<Comment> GetComments(int id);
        bool CommentsInList(List<Comment> comments);
    }
}
