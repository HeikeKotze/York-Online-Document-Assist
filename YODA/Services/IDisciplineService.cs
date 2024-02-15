using YODA.Repos.Models;

namespace YODA.Services
{
    public interface IDisciplineService
    {
        List<Offence> GetOffenceList();
        List<Offence> GetOffencesForCounsellingNotes();
        List<BreachType> GetBreachTypeList();
        List<OffenceBreach> EmployeeBreaches(int id);
        List<OffenceBreach> GetAllDisciplinaries();
        List<AppealDiscipline> GetAppealDisciplines();
        List<GroundsOfAppeal> GetGroundsOfAppeals();
        List<AppealOutcomes> GetAppealOutcomes();
        void SaveDiscipline(List<OffenceBreach> offenceBreachList);
        void DeleteDiscipline(int id);
        void DeleteCounsellingNote(int id);

        string? GetOffenceName(int id);
        string? GetBreachname(int id);
        void SaveCounsellingNote(CounsellingNotes note);
        void UpdateCounsellingNote(CounsellingNotes note);
        List<CounsellingNotes> GetCounsellingNotesForEmp(int id);
        List<CounsellingNotes> GetAllCousellingNotes();
        List<OffenceBreach> GetAllDisciplinariesForAllocation();
        void AddOffenceBreach(OffenceBreach breach);
        void UpdateOffenceBreach(OffenceBreach breach);
        void ApproveDiscipline(OffenceBreach discipline);
        void SetOutcomeForDiscipline(OffenceBreach discipline);

        OffenceBreach GetDisciplineByID (int id);
        CounsellingNotes GetNoteByID (int id);
        void SaveCommentForDiscipline(int id, string comment);
        void SetDisciplineAsEditable(int id);
        void UpdateCounsellingNoteAfterDocumentUpload(CounsellingNotes note);
        void AddAppealDiscipline(AppealDiscipline discipline);
        List<DisciplineProcess> GetDisciplineProcesses();

        void ChangeDisciplineProcess(int disciplineid, int processid);
        AppealDiscipline GetAppealDiscipline(int disciplineid);
        DisciplineProcess GetDisciplineProcess(int processid);
        void ChangeOutcomeOfAppeal(int appealid,  int outcomeid);
        void ChangeOutcomeOfDiscipline(OffenceBreach breach, int outcomeid);
        void ChangeSentToInvictusStatusAfterAppeal(OffenceBreach breach);
        
    }
}
