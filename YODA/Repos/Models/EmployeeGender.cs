using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeGender")]
    public class EmployeeGender
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("GenderName")]
        public string? GenderName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
