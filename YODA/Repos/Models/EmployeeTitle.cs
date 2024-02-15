using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeTitle")]
    public class EmployeeTitle
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("TitleName")]
        public string? TitleName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
