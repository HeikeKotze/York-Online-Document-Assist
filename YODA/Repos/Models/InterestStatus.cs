using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("InterestStatus")]
    public class InterestStatus
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("StatusName")]
        public string? StatusName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
