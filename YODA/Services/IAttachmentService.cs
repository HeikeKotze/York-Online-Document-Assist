using YODA.Repos.Models;


namespace YODA.Services
{
    public interface IAttachmentService
    {
        List<AttachmentType> GetAttachments();
        public void deleteAttachmentsByCapex(int? id);
        public List<FkAttachmentsCapex> findAttachmentsByCapex(int? id);
        public void saveAttachments(List<FkAttachmentsCapex> attach);

        string GetAttachmentName(int id);

    }
}
