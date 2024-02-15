using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("fkKPICapex")]
public partial class FkKpicapex
{
    [Key]
    [Column("fkKC_ID")]
    public int FkKcId { get; set; }

    [Column("fkKC_KPI")]
    public int FkKcKpi { get; set; }

    [Column("fkKC_CapexForm")]
    public int FkKcCapexForm { get; set; }

    [Column("fkKC_Description")]
    public string? FkKcDescription { get; set; }

    [ForeignKey("FkKcCapexForm")]
    [InverseProperty("FkKpicapexes")]
    public virtual CapexForm FkKcCapexFormNavigation { get; set; } = null!;

    [ForeignKey("FkKcKpi")]
    [InverseProperty("FkKpicapexes")]
    public virtual Kpi FkKcKpiNavigation { get; set; } = null!;
}
