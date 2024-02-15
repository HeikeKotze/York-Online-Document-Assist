using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("Role")]
public partial class Role
{
    [Key]
    [Column("RoleID")]
    public int RoleId { get; set; }

    [StringLength(50)]
    public string? RoleName { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<CapexUser> CapexUsers { get; set; } = new List<CapexUser>();

    [InverseProperty("FkScSignatoryRole")]
    public virtual ICollection<FkSignatoriesCapex> FkSignatoriesCapexes { get; set; } = new List<FkSignatoriesCapex>();
}
