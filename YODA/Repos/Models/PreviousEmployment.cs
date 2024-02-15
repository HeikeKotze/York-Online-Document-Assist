using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("PreviousEmployment")]
    public class PreviousEmployment
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("Employer")]
        public string? Employer { get; set; }
        [Column("DateStart")]
        public DateTime DateStart { get; set; } = DateTime.Now;
        [Column("DateEnd")]
        public DateTime DateEnd { get; set; } = DateTime.Now;
        [Column("JobTitle")]
        public string? JobTitle { get; set; }
        [Column("Salary")]
        public string? Salary { get; set; }
        [Column("ReasonLeaving")]
        public string? ReasonLeaving { get; set; }
    }
}
