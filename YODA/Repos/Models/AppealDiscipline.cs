using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("AppealDiscipline")]
    public class AppealDiscipline
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("OffenceBreachID")]
        public int OffenceBreachID { get; set; }
        [Column("GroundsOfAppealID")]
        public int GroundsOfAppealID { get; set; }
        [Column("Reason")]
        public string? Reason { get; set; }
        [Column("DateOfAppeal")]
        public DateTime? DateOfAppeal { get; set; }
        [Column("OutcomeID")]
        public int? OutcomeID { get; set; }
        [Column("OutcomeDateReceived")]
        public DateTime? OutcomeDateReceived { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
        [NotMapped]
        public string? OutcomeString { get; set; }
    }
}
