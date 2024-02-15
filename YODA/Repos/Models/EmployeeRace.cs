using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeRace")]
    public class EmployeeRace
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("RaceName")]
        public string? RaceName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
