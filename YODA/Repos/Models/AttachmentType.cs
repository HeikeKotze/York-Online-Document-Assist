using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

public partial class AttachmentType
{
    [Key]
    [Column("AttachmentID")]
    public int AttachmentId { get; set; }

    [StringLength(50)]
    public string? AttachmentName { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [InverseProperty("FkAcAttachmentTypesNavigation")]
    public virtual ICollection<FkAttachmentsCapex> FkAttachmentsCapexes { get; set; } = new List<FkAttachmentsCapex>();

    public string? File { get; set; }
    public string? Path { get; set; }
}
