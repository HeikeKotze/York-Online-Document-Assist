using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeePayPeriod")]
    public class EmployeePayPeriod
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("PayPeriodName")]
        public string? PayPeriodName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
