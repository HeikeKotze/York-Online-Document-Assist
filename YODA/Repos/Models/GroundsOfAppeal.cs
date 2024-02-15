using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("GroundsOfAppeal")]
    public class GroundsOfAppeal
    {
        [Key][Column("Id")]
        public int Id { get; set; }
        [Column("NameOfGrounds")]
        public string? NameOfGrounds { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
