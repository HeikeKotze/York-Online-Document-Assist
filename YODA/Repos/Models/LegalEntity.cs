using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("LegalEntity")]
public partial class LegalEntity
{
    [Key]
    [Column("LegalEntityID")]
    public int LegalEntityId { get; set; }

    [StringLength(50)]
    public string? LegalEntityName { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [InverseProperty("LegalEntity")]
    public virtual ICollection<BusinessUnit> BusinessUnits { get; set; } = new List<BusinessUnit>();
}
