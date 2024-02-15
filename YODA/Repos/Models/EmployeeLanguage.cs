using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace YODA.Repos.Models
{
    [Table("EmployeeLanguage")]
    public class EmployeeLanguage
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("LanguageName")]
        public string? LanguageName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
