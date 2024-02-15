using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("BusinessUnit")]
public partial class BusinessUnit
{
    [Key]
    [Column("BusinessUnitID")]
    public int BusinessUnitId { get; set; }

    [StringLength(50)]
    public string? BusinessUnitName { get; set; }

    [Column("LegalEntityID")]
    public int? LegalEntityId { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [InverseProperty("BusinessUnit")]
    public virtual ICollection<CapexUser> CapexUsers { get; set; } = new List<CapexUser>();

    [ForeignKey("LegalEntityId")]
    [InverseProperty("BusinessUnits")]
    public virtual LegalEntity? LegalEntity { get; set; }

    [InverseProperty("BusinessUnit")]
    public virtual ICollection<Site> Sites { get; set; } = new List<Site>();
}
