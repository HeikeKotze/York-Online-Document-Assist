using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("LicenceCodes")]
    public class LicenceCodes
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("LicenceCodeID")]
        public int? LicenceCodeID { get; set; }
        [NotMapped]
        public string? LicenceCodeName { get; set; }
    }
}
