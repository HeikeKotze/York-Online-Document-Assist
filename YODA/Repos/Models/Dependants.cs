using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("Dependants")]
    public class Dependants
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("Surname")]
        public string? Surname { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
        [Column("Relationship")]
        public string? Relationship { get; set; }
        [Column("Gender")]
        public string? Gender { get; set; }
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
}
