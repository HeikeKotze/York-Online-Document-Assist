using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeJobGrade")]
    public class EmployeeJobGrade
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("JobGradeName")]
        public string? JobGradeName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
