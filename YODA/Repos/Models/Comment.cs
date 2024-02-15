using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

public partial class Comment
{
    [Key]
    [Column("CommentID")]
    public int CommentId { get; set; }

    [Column("fk_CapexID")]
    public int? FkCapexId { get; set; }

    [StringLength(50)]
    public string? FormSection { get; set; }

    public string? Consentee { get; set; }

    [Column("Comment")]
    public string? Comments { get; set; }

    [ForeignKey("FkCapexId")]
    [InverseProperty("Comments")]
    public virtual CapexForm? FkCapex { get; set; }
}
