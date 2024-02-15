using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("Beneficiaries")]
    public class Beneficiaries
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("FullName")]
        public string? FullName { get; set; }
        [Column("Relationship")]
        public string? Relationship { get; set; }
        [Column("IDNumber")]
        public string? IDNumber { get; set; }
        [Column("PercentageOfBenefit")]
        public int PercentageOfBenefit { get; set; }
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
