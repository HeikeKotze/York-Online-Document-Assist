using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EducationalHistory")]
    public class EducationalHistory
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("PlaceOfStudy")]
        public string? PlaceOfStudy { get; set; }
        [Column("StartDate")]
        public DateTime? StartDate { get; set; } = DateTime.Now;
        [Column("EndDate")]
        public DateTime? EndDate { get; set;} = DateTime.Now;
        [Column("Subjects")]
        public string? Subjects { get; set; }
        [Column("Qualification")]
        public string? Qualification { get; set; }
    }
}
