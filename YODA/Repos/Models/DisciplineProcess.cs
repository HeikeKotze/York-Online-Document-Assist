using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("DisciplineProcess")]
    public class DisciplineProcess
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ProcessName")]
        public string? ProcessName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
        
    }
}
