using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("ServerPathConfig")]
    public class ServerPathConfig
    {
        [Key][Column("Id")]
        public int Id { get; set; }
        [Column("PathName")]
        public string? PathName { get; set; }
        [Column("PathValue")]
        public string? PathValue { get; set; }
        [Column("recStatus")]
        public short? recStatus { get; set; }
        [Column("ModuleID")]
        public int? ModuleID { get; set; }
    }
}
