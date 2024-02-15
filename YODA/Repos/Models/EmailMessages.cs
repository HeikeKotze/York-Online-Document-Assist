using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmailMessages")]
    public class EmailMessages
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("MessageName")]
        public string? MessageName { get; set; }
        [Column("PlaceUsed")]
        public string? PlaceUsed { get; set; }
        [Column("MessageToMail")]
        public string? MessageToMail { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
    }
}
