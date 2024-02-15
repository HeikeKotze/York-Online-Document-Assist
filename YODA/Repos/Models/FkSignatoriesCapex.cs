using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("fkSignatoriesCapex")]
public partial class FkSignatoriesCapex
{
    [Key]
    [Column("fkSC_ID")]
    public int FkScId { get; set; }

    [Column("fkSC_CapexForm")]
    public int FkScCapexForm { get; set; }

    [Column("fkSC_SignatoryID")]
    public int FkScSignatoryId { get; set; }

    [Column("fkSC_SignatoryRoleID")]
    public int FkScSignatoryRoleId { get; set; }

    [Column("fkSC_SignatoryDate", TypeName = "date")]
    public DateTime? FkScSignatoryDate { get; set; }

    [Column("fkSC_SignedConfirmation")]
    public short? FkScSignedConfirmation { get; set; }

    [Column("fkSC_Reason")]
    [Unicode(false)]
    public string? FkScReason { get; set; }

    [ForeignKey("FkScCapexForm")]
    [InverseProperty("FkSignatoriesCapexes")]
    public virtual CapexForm FkScCapexFormNavigation { get; set; } = null!;

    [ForeignKey("FkScSignatoryId")]
    [InverseProperty("FkSignatoriesCapexes")]
    public virtual CapexUser? FkScSignatory { get; set; }

    [ForeignKey("FkScSignatoryRoleId")]
    [InverseProperty("FkSignatoriesCapexes")]
    public virtual Role? FkScSignatoryRole { get; set; }
    
    [NotMapped]
    public string? UserName { get; set; }
}
