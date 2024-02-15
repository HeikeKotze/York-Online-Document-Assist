using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("LanguageProficiency")]
    public class LanguageProficiency
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("LanguageID")]
        public int? LanguageID { get; set; }
        [Column("Speak")]
        public string? Speak { get; set; }
        [Column("Read")]
        public string? Read { get; set; }
        [Column("Write")]
        public string? Write { get; set; }
        [NotMapped]
        public string? LanguageName { get; set; }
    }
}
