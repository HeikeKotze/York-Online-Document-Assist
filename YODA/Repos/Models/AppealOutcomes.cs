using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("AppealOutcomes")]
    public class AppealOutcomes
    {
        [Key][Column("Id")]
        public int Id { get; set; }
        [Column("OutcomeName")]
        public string? OutcomeName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
