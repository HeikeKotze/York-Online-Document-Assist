using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("CounsellingNotes")]
    public class CounsellingNotes
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("DateOfConsultation")]
        public DateTime? DateOfConsultation { get; set; }
        [Column("ViolationDetails")]
        public string? ViolationDetails { get; set; }
        [Column("EmployeeResponse")]
        public string? EmployeeResponse { get; set; }
        [Column("ActionPlan")]
        public string? ActionPlan { get; set; }
        [Column("FollowUpDate")]
        public DateTime? FollowUpDate { get; set; }
        [Column("OffenceID")]
        public int? OffenceID { get; set; }
        [Column("ElectronicSignDate")]
        public DateTime? ElectronicSignDate { get; set; }
        [Column("ElectronicSignConfirmation")]
        public int? ElectronicSignConfirmation { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
        [Column("ConsultantID")]
        public int? ConsultantID { get; set; }
        [Column("SubmissionStatus")]
        public short? SubmissionStatus { get; set; }
        [Column("SignedNoteSubmitted")]
        public DateTime? SignedNoteSubmitted { get; set; }
        [NotMapped]
        public string? SubmissionStatusString { get; set; }
        [NotMapped]
        public string? ConsultantName { get; set; }
        [NotMapped]
        public string? OffenceName { get; set; }
        [NotMapped]
        public string? DateString { get; set; }
    }
}
