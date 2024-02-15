using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("LocationCostCode")]
public partial class LocationCostCode
{
    [Key]
    [Column("LocationCostCodeID")]
    public int LocationCostCodeId { get; set; }

    [StringLength(50)]
    public string? LocationCostCodeName { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [InverseProperty("LocationCostCode")]
    public virtual ICollection<CapexForm> CapexForms { get; set; } = new List<CapexForm>();
}
