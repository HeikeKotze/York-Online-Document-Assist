using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("AccessLinking")]
    public class AccessLinking
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("BusinessUnitID")]
        public int BusinessUnitID { get; set; }
        [Column("DepartmentID")]
        public int DepartmentID { get; set; }
        [Column("RoleID")]
        public int RoleID { get; set; }
        [Column("ModuleID")]
        public int ModuleID { get; set; }
        [Column("AccessTypeID")]
        public int AccessTypeID { get; set; }
        [Column("RecStatus")]
        public int RecStatus { get; set; }

    }
}
