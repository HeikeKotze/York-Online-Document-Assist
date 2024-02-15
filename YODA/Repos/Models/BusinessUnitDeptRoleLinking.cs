using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("BusinessUnitDeptLinking")]
    public class BusinessUnitDeptRoleLinking
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("BusinessUnitID")]
        public int BusinessUnitID { get; set; }
        [Column("DepartmentID")]
        public int DepartmentID { get; set; }
        [Column("RoleID")]
        public int? RoleID { get; set; }
        [Column("RecStatus")]
        public short RecStatus { get; set; }
    }
}
