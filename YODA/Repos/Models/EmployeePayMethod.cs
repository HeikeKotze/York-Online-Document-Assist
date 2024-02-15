using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeePayMethod")]
    public class EmployeePayMethod
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("PayMethodName")]
        public string? PayMethodName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
