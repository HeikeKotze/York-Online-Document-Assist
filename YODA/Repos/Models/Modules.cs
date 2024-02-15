using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("Modules")]
    public class Modules
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ModuleName")]
        public string? ModuleName { get; set; }
        [Column("recStatus")]
        public int recStatus { get; set; }
    }
}
