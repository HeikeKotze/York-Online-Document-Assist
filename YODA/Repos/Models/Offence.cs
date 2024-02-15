using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("Offence")]
    public class Offence
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("OffenceName")]
        public string? OffenceName { get; set; }
        [Column("ViolationDegree")]
        public int? ViolationDegree { get; set; }
        [Column("recStatus")]
        public short? recStatus { get; set; }
    }
}
