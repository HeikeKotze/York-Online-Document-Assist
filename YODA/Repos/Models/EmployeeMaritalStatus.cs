using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeMaritalStatus")]
    public class EmployeeMaritalStatus
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("MaritalStatusName")]
        public string? MaritalStatusName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
