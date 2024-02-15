using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("BalanceSheetCode")]
public partial class BalanceSheetCode
{
    [Key]
    [Column("BalanceSheetCodeID")]
    public int BalanceSheetCodeId { get; set; }

    [StringLength(50)]
    public string? BalanceSheetCodeName { get; set; }

    [Column("RecStatus")]
    public short? RecStatus { get; set; }

    [InverseProperty("BalanceSheetCode")]
    public virtual ICollection<CapexForm> CapexForms { get; set; } = new List<CapexForm>();
}
