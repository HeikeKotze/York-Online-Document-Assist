using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("LinkedDocuments")]
    public class LinkedDocuments
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("FileTypeID")]
        public int? FileTypeID { get; set; }
        [Column("DescriptionOther")]
        public string? DescriptionOther { get; set; }
        [Column("FullFileName")]
        public string? FullFileName { get; set; }
        [Column("OffenceBreachID")]
        public int? OffenceBreachID { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
        [NotMapped]
        public string? FileTypeName { get; set; }
        [NotMapped]
        public string? FileName { get; set; } = string.Empty;
    }
}
