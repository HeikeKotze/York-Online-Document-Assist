using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("CapexUser")]
public partial class CapexUser
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string? UserName { get; set; }

    [StringLength(50)]
    public string? UserPassword { get; set; }

    [Column("BusinessUnitID")]
    public int BusinessUnitId { get; set; }

    [Column("RoleID")]
    public int? RoleId { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }
    [Column("Lock")]
    public short? Lock { get; set; }
    [Column("NewUser")]
    public short? NewUser { get; set; }

    [ForeignKey("BusinessUnitId")]
    [InverseProperty("CapexUsers")]
    public virtual BusinessUnit? BusinessUnit { get; set; }

    [InverseProperty("FkScSignatory")]
    public virtual ICollection<FkSignatoriesCapex> FkSignatoriesCapexes { get; set; } = new List<FkSignatoriesCapex>();

    [ForeignKey("RoleId")]
    [InverseProperty("CapexUsers")]
    public virtual Role? Role { get; set; }
    [NotMapped]
    public string? RoleName { get; set; }
    [NotMapped]
    public DateTime? SignDate { get; set; }
    [NotMapped]
    public bool Success { get; set; }
}
