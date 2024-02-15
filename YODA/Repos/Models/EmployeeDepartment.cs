using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeDepartment")]
    public class EmployeeDepartment
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("DepartmentName")]
        public string? DepartmentName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
