using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

public partial class Risk
{
    [Key]
    [Column("RisksID")]
    public int RisksId { get; set; }

    [Column("fk_CapexID")]
    public int? FkCapexId { get; set; }

    public string? RiskDescription { get; set; }

    [StringLength(10)]
    public string? ConsequenceClassification { get; set; }

    [StringLength(10)]
    public string? LikelihoodClassification { get; set; }

    public string? ImpactOn { get; set; }

    public string? MitigatingStrategy { get; set; }

    [ForeignKey("FkCapexId")]
    [InverseProperty("Risks")]
    public virtual CapexForm? FkCapex { get; set; }
}
