using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("fkAttachmentsCapex")]
public partial class FkAttachmentsCapex
{
    [Key]
    [Column("fkAC_ID")]
    public int FkAcId { get; set; }

    [Column("fkAC_AttachmentTypes")]
    public int FkAcAttachmentTypes { get; set; }

    [Column("fkAC_CapexForm")]
    public int FkAcCapexForm { get; set; }

    [Column("fkAC_File")]
    [Unicode(false)]
    public string? FkAcFile { get; set; }

    [Column("fkAC_Path")]
    public string? FkAcPath { get; set; }

    [ForeignKey("FkAcAttachmentTypes")]
    [InverseProperty("FkAttachmentsCapexes")]
    public virtual AttachmentType FkAcAttachmentTypesNavigation { get; set; } = null!;

    [ForeignKey("FkAcCapexForm")]
    [InverseProperty("FkAttachmentsCapexes")]
    public virtual CapexForm FkAcCapexFormNavigation { get; set; } = null!;
}
