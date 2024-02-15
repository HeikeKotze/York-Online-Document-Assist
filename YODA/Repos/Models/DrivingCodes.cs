using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("DrivingCodes")]
    public class DrivingCodes
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("LicenceCodeName")]
        public string? LicenceCodeName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
