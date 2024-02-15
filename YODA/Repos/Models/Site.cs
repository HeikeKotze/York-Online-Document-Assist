using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("Site")]
public partial class Site
{
    [Key]
    [Column("SiteID")]
    public int SiteId { get; set; }

    [Column("SiteName")]
    [StringLength(50)]
    public string? SiteName { get; set; }

    [Column("BusinessUnitID")]
    public int? BusinessUnitId { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [ForeignKey("BusinessUnitId")]
    [InverseProperty("Sites")]
    public virtual BusinessUnit? BusinessUnit { get; set; }

    [InverseProperty("Site")]
    public virtual ICollection<CapexForm> CapexForms { get; set; } = new List<CapexForm>();
}
