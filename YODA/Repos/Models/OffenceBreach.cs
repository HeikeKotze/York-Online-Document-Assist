using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("OffenceBreach")]
    public class OffenceBreach
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("OffenceID")]
        public int OffenceID { get; set; }
        [Column("BreachTypeID")]
        public int BreachTypeID { get; set; }
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("recStatus")]
        public short? recStatus { get; set; }
        [Column("Date")]
        public DateTime? Date { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
        [Column("SiteID")]
        public int? SiteID { get; set; }
        [Column("DateSuspended")]
        public DateTime? DateSuspended { get; set; }
        [Column("HearingAddress")]
        public string? HearingAddress { get; set; }
        [Column("ApprovedForSend")]
        public short? ApprovedForSend { get; set; }
        [Column("OutcomeDescription")]
        public string? OutcomeDescription { get; set; }
        [Column("SubmissionStatus")]
        public short? SubmissionStatus { get; set; }
        [Column("Comment")]
        public string? Comment { get; set; }
        [Column("SuperiorID")]
        public int? SuperiorID { get; set; }
        [Column("SentToInvictus")]
        public int? SentToInvictus { get; set; }
        [Column("DisciplineProcessID")]
        public int DisciplineProcessID { get; set; }

        //Not Mapped information ------------------
        [NotMapped]
        public string? SubmissionStatusString { get; set; }
        [NotMapped]
        public string? OffenceName { get; set; }
        [NotMapped]
        public string? BreachName { get;set; }
        [NotMapped]
        public string? EmployeeName { get; set;}
        [NotMapped]
        public string? SiteName { get; set;}
        [NotMapped]
        public string? DateString { get; set; }
        [NotMapped]
        public string? RoleName { get; set; }
        [NotMapped]
        public string? SuspendedDateString { get; set; }
        [NotMapped]
        public string? EmployeeNumber { get; set; }
        [NotMapped]
        public string? EmployeeRace { get; set; }
        [NotMapped]
        public string? EmployeeGender { get; set; }
        [NotMapped]
        public string? ProcessString { get; set; }
    }
}
