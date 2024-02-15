using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YODA.Pages.CapexComponents;
using YODA.Repos;
using YODA.Repos.Models;

namespace YODA.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly dbfirstcontext _dbc;
        public DisciplineService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }

        public void AddAppealDiscipline(AppealDiscipline discipline)
        {
            var newAppeal = new AppealDiscipline
            {
                OffenceBreachID = discipline.OffenceBreachID,
                GroundsOfAppealID = discipline.GroundsOfAppealID,
                Reason = discipline.Reason,
                DateOfAppeal = discipline.DateOfAppeal,
                RecStatus = discipline.RecStatus,
                OutcomeDateReceived = null,
                OutcomeID = null
            };
            _dbc.Add(newAppeal);
            _dbc.SaveChanges();
        }

        public void AddOffenceBreach(OffenceBreach breach)
        {
            try
            {
                var newDiscipline = new OffenceBreach
                {
                    OffenceID = breach.OffenceID,
                    EmployeeID = breach.EmployeeID,
                    BreachTypeID = breach.BreachTypeID,
                    Description = breach.Description,
                    Date = breach.Date,
                    SiteID = breach.SiteID,
                    DateSuspended = breach.DateSuspended,
                    HearingAddress = breach.HearingAddress,
                    ApprovedForSend = breach.ApprovedForSend,
                    SubmissionStatus = breach.SubmissionStatus,
                    recStatus = breach.recStatus,
                    SuperiorID = breach.SuperiorID,
                    SentToInvictus = breach.SentToInvictus,
                    DisciplineProcessID = breach.DisciplineProcessID,
                };
                _dbc.Add(newDiscipline);
                _dbc.SaveChanges();
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

        public void ApproveDiscipline(OffenceBreach discipline)
        {
            var disciplineDB = _dbc.OffenceBreaches
                .Where(x => x.Id == discipline.Id)
                .FirstOrDefault();
            if( disciplineDB != null)
            {
                disciplineDB.ApprovedForSend = 1;
                _dbc.OffenceBreaches.Update(disciplineDB);
                _dbc.SaveChanges();
            }
            else
            {
                _dbc.SaveChanges(false);
            }
        }

        public void ChangeDisciplineProcess(int disciplineid, int processid)
        {
            try
            {
                var item = _dbc.OffenceBreaches.Where(x=>x.Id == disciplineid).FirstOrDefault();
                if( item != null )
                {
                    item.DisciplineProcessID = processid;
                    _dbc.OffenceBreaches.Update(item);
                    _dbc.SaveChanges();
                }
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

        public void ChangeOutcomeOfAppeal(int appealid, int outcomeid)
        {
            var item = _dbc.AppealDisciplines.Where(x=>x.Id==appealid).FirstOrDefault();
            if( item != null )
            {
                item.OutcomeID = outcomeid;
                _dbc.AppealDisciplines.Update(item);
                _dbc.SaveChanges();
            }
        }

        public void ChangeOutcomeOfDiscipline(OffenceBreach breach, int outcomeid)
        {
            var item = _dbc.OffenceBreaches.Where(x=>x.Id == breach.Id).FirstOrDefault();
            if( item != null )
            {
                item.BreachTypeID = outcomeid;
                item.BreachName = "";
                _dbc.OffenceBreaches.Update(item) ;
                _dbc.SaveChanges();

            }
        }

        public void ChangeSentToInvictusStatusAfterAppeal(OffenceBreach breach)
        {
            var item = _dbc.OffenceBreaches.Where(x => x.Id == breach.Id).FirstOrDefault();
            if( item != null )
            {
                item.SentToInvictus = 0;
                _dbc.OffenceBreaches.Update(item);
                _dbc.SaveChanges();
            }
        }

        public void DeleteCounsellingNote(int id)
        {
            try
            {
                var item = _dbc.CounsellingNotes
                .Where(x => x.Id == id)
                .FirstOrDefault();

                if (item != null)
                {
                    item.RecStatus = 1001;
                    _dbc.CounsellingNotes.Update(item);
                    _dbc.SaveChanges();
                }
                else
                {
                    _dbc.SaveChanges(false);
                }

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

        public void DeleteDiscipline(int id)
        {
            try
            {
                var item = _dbc.OffenceBreaches
                .Where(x => x.Id == id)
                .FirstOrDefault();

                if ( item != null )
                {
                    item.recStatus = 1001;
                    _dbc.OffenceBreaches.Update(item);
                    _dbc.SaveChanges();
                }
                else
                {
                    _dbc.SaveChanges(false);
                }
                
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

        public List<OffenceBreach> EmployeeBreaches(int id)
        {
            var list = _dbc.OffenceBreaches
                .Where(x=>x.EmployeeID == id && x.recStatus == 1)
                .ToList();
            return list;
        }

        public List<CounsellingNotes> GetAllCousellingNotes()
        {
            var list = _dbc.CounsellingNotes
                .ToList();
            return list;
        }

        public List<OffenceBreach> GetAllDisciplinaries()
        {
            return _dbc.OffenceBreaches .ToList();
        }

        public List<OffenceBreach> GetAllDisciplinariesForAllocation()
        {
            //No outcome
            var list = _dbc.OffenceBreaches
                .Where(x=>x.SentToInvictus == 0 && x.recStatus == 1 && x.SubmissionStatus == 1)
                .ToList();
            if (list != null)
            {
                return list;
            }
            else return new List<OffenceBreach>();
        }

        public AppealDiscipline GetAppealDiscipline(int disciplineid)
        {
            var item = _dbc.AppealDisciplines
                .Where(x=>x.OffenceBreachID == disciplineid)
                .FirstOrDefault();
            if (item != null)
            {
                return item;
            }
            else
            {
                return new AppealDiscipline();
            }
        }

        public List<AppealDiscipline> GetAppealDisciplines()
        {
            return _dbc.AppealDisciplines.ToList();
        }

        public List<AppealOutcomes> GetAppealOutcomes()
        {
            return _dbc.AppealOutcomes.ToList();
        }

        public string? GetBreachname(int id)
        {
            var breach = _dbc.BreachTypes
                .Where(x => x.Id == id)
                .Select(x => x.BreachName)
                .FirstOrDefault();
            if (breach != null)
            {
                return breach;
            }
            else
            {
                return "";
            }

        }

        public List<BreachType> GetBreachTypeList()
        {
            return _dbc.BreachTypes.ToList();
        }

        public List<CounsellingNotes> GetCounsellingNotesForEmp(int id)
        {
            try
            {

                var list = _dbc.CounsellingNotes
                    .Where(x=>x.EmployeeID == id && x.RecStatus == 1)
                    .ToList ();
                if(list != null)
                {
                    return list;
                }
                else
                {
                    return new List<CounsellingNotes>() ;
                }
                
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

        public OffenceBreach GetDisciplineByID(int id)
        {
            try
            {
                var offence = _dbc.OffenceBreaches
                    .Where(x=>x.Id == id)
                    .FirstOrDefault();
                if(offence != null)
                {
                    return offence;
                }
                else
                {
                    return new OffenceBreach() ;
                }
                
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

        public DisciplineProcess GetDisciplineProcess(int processid)
        {
            var item = _dbc.DisciplineProcesses.Where(x=>x.Id ==processid).FirstOrDefault();
            if (item != null)
            {
                return item;
            }
            else { return new DisciplineProcess() ; }
        }

        public List<DisciplineProcess> GetDisciplineProcesses()
        {
            return _dbc.DisciplineProcesses.Where(x=>x.RecStatus ==1 ).ToList();
        }

        public List<GroundsOfAppeal> GetGroundsOfAppeals()
        {
            return _dbc.GroundsOfAppeals.ToList();
        }

        public CounsellingNotes GetNoteByID(int id)
        {
            try
            {
                var note = _dbc.CounsellingNotes
                    .Where(x=>x.Id == id)
                    .FirstOrDefault();
                if(note != null)
                {
                    return note;
                }
                else
                {
                    return new CounsellingNotes() ;
                }
                
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

        public List<Offence> GetOffenceList()
        {
            return _dbc.Offences.ToList();
        }

        public string? GetOffenceName(int id)
        {
      
            var offence = _dbc.Offences
                .Where(x => x.Id == id)
                .Select(x => x.OffenceName)
                .FirstOrDefault();
            if(offence != null)
            {
                return offence;
            }
            else
            {
                return "";
            }
            
        }

        public List<Offence> GetOffencesForCounsellingNotes()
        {
            return _dbc.Offences.Where(x => x.ViolationDegree == 2).ToList();
        }

        public void SaveCommentForDiscipline(int id, string comment)
        {
            try
            {
                var item = _dbc.OffenceBreaches
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                if(item != null)
                {
                    item.Comment = comment;
                    _dbc.OffenceBreaches.Update(item);
                    _dbc.SaveChanges();
                }
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

        public void SaveCounsellingNote(CounsellingNotes note)
        {
            try
            {
                _dbc.CounsellingNotes.Add(note);
                _dbc.SaveChanges();
            }
            catch(Exception e)
            {
                // Get the stack trace as a string
                string stackTrace = new StackTrace(e).ToString();

                // Log or display the stack trace
                Console.WriteLine("Exception caught:");
                Console.WriteLine(e.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(stackTrace);
                throw;
            }
        }

        public void SaveDiscipline(List<OffenceBreach> offenceBreachList)
        {
            try
            {
                foreach(var item in offenceBreachList)
                {
                    var newOffence = new OffenceBreach
                    {
                        OffenceID = item.OffenceID,
                        BreachTypeID = item.BreachTypeID,
                        EmployeeID = item.EmployeeID,
                        Description = item.Description,
                        Date = item.Date,
                        recStatus = item.recStatus
                    };
                    _dbc.OffenceBreaches.Add(newOffence);
                }
                _dbc.SaveChanges();
                
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

        public void SetDisciplineAsEditable(int id)
        {
            var item = _dbc.OffenceBreaches
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if(item != null)
            {
                item.SubmissionStatus = 0;
                _dbc.OffenceBreaches.Update(item);
                _dbc.SaveChanges();
            }
        }

        public void SetOutcomeForDiscipline(OffenceBreach discipline)
        {
            var offencebreachDB = _dbc.OffenceBreaches
                .Where(x => x.Id == discipline.Id && x.ApprovedForSend == 1)
                .FirstOrDefault();

            if(offencebreachDB != null)
            {
                offencebreachDB.BreachTypeID = discipline.BreachTypeID;
                offencebreachDB.OutcomeDescription = discipline.OutcomeDescription;
                _dbc.OffenceBreaches.Update(offencebreachDB);
                _dbc.SaveChanges();
            }
            else
            {
                _dbc.SaveChanges(false);
            }
        }

        public void UpdateCounsellingNote(CounsellingNotes note)
        {
            try
            {

                var existingNote = _dbc.CounsellingNotes.FirstOrDefault(x=>x.Id == note.Id);

                if(existingNote != null)
                {
                    // Update the properties of the existing entity
                    _dbc.Entry(existingNote).CurrentValues.SetValues(note);

                    // Mark the entity as modified
                    _dbc.Entry(existingNote).State = EntityState.Modified;

                    // Save changes
                    _dbc.SaveChanges();
                }
                else
                {
                    _dbc.SaveChanges(false);
                }
                
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

        public void UpdateCounsellingNoteAfterDocumentUpload(CounsellingNotes note)
        {
            _dbc.CounsellingNotes.Update(note);
            _dbc.SaveChanges();
        }

        public void UpdateOffenceBreach(OffenceBreach breach)
        {
            try
            {
                var existingDiscipline = _dbc.OffenceBreaches.FirstOrDefault(x => x.Id == breach.Id);

                if (existingDiscipline != null)
                {
                    // Update the properties of the existing entity
                    _dbc.Entry(existingDiscipline).CurrentValues.SetValues(breach);

                    // Mark the entity as modified
                    _dbc.Entry(existingDiscipline).State = EntityState.Modified;

                    // Save changes
                    _dbc.SaveChanges();
                }
                else
                {
                    _dbc.SaveChanges(false);
                }
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
    }
}
