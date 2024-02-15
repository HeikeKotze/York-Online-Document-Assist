using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("ProjectCategory")]
public partial class ProjectCategory
{
    [Key]
    [Column("ProjectCategoryID")]
    public int ProjectCategoryId { get; set; }

    [StringLength(50)]
    public string? ProjectCategoryName { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [InverseProperty("ProjectCategory")]
    public virtual ICollection<CapexForm> CapexForms { get; set; } = new List<CapexForm>();
}
