using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeNationality")]
    public class EmployeeNationality
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nationalityname")]
        public string? NationalityName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
