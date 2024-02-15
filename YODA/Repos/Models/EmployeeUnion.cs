using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeUnion")]
    public class EmployeeUnion
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("UnionName")]
        public string? UnionName { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
    }
}
