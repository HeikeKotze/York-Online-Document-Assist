using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("KPI")]
public partial class Kpi
{
    [Key]
    [Column("KPIID")]
    public int Kpiid { get; set; }

    [Column("KPIName")]
    [StringLength(150)]
    public string? Kpiname { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [InverseProperty("FkKcKpiNavigation")]
    public virtual ICollection<FkKpicapex> FkKpicapexes { get; set; } = new List<FkKpicapex>();

    public string? KpiDescription { get; set; }
}
