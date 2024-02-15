using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("FileTypes")]
    public class FileTypes
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("FileTypeName")]
        public string? FileTypeName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
        [Column("PrePostDisciplinary")]
        public int? PrePostDisciplinary { get; set; }
    }
}
