using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace YODA.Repos.Models
{
    [Table("RequestPassword")]
    public class RequestPassword
    {
        [Key][Column("Id")]
        public int Id { get; set; }
        [Column("EmpID")]
        public int? EmpID { get; set; }
        [Column("Code")]
        public string? Code { get; set; }
        [Column("DateRequested")]
        public DateTime? DateRequested { get; set; }
    }
}
