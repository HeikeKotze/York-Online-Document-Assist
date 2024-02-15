using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("AssetCategory")]
public partial class AssetCategory
{
    [Key]
    [Column("AssetCategoryID")]
    public int AssetCategoryId { get; set; }

    [StringLength(50)]
    public string? AssetCategoryName { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [InverseProperty("AssetCategory")]
    public virtual ICollection<CapexForm> CapexForms { get; set; } = new List<CapexForm>();
}
