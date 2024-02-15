using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("BreachType")]
    public class BreachType
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("BreachName")]
        public string? BreachName { get; set; }
    }
}
