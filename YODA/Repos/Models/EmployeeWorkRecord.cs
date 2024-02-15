using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("EmployeeWorkRecord")]
    public class EmployeeWorkRecord
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("BUDeptRoleID")]
        public int BUDeptRoleID { get; set; }
        [Column("EmpID")]
        public int EmpID { get; set; }
        [Column("RecStatus")]
        public short RecStatus { get; set; }
        [Column("FromDate")]
        public DateTime? FromDate { get; set; } = DateTime.Now;
        [Column("ToDate")]
        public DateTime? ToDate { get; set; }
        [NotMapped]
        public string? BusinessUnitName { get; set; }
        [NotMapped]
        public string? DepartmentName { get; set; }
        [NotMapped]
        public string? RoleName { get; set; }
        [NotMapped]
        public string? ModuleName { get; set; }
        [NotMapped]
        public string? AccessTypeName { get; set; }
        [NotMapped]
        public string? FromDateString { get; set; }
        [NotMapped]
        public string? ToDateString { get;set; }
        [NotMapped]
        public string? Status { get; set; }
        [NotMapped]
        public string? EntityName { get; set; }
    }
}
