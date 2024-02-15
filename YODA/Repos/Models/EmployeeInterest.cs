using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeInterest")]
    public class EmployeeInterest
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("EmpID")]
        public int? EmpID { get; set; }
        [Column("DateSubmitted")]
        public DateTime? DateSubmitted { get; set; }
        [Column("NatureOfConflict")]
        public string? NatureOfConflict { get; set; }
        [Column("DateUpgraded")]
        public DateTime? DateUpgraded { get; set; }
        [Column("Type")]
        public string? Type { get; set; }
        [Column("StatusID")]
        public int? StatusID { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
