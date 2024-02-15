using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("CapexForm")]
public partial class CapexForm
{
    
    [Key]
    [Column("CapexID")]
    public int CapexId { get; set; }

    [Required(ErrorMessage = "Capex Title is required.")]
    public string? CapexTitle { get; set; }

    [StringLength(50)]
    public string? ProjectNumber { get; set; }

    [Required(ErrorMessage = "Initiator is required.")]
    public string? Initiator { get; set; }

    [Column("CompanyID")]
    [Required(ErrorMessage ="Legal Entity is required.")]
    public int? CompanyId { get; set; }

    [Column("SiteID")]
    public int? SiteId { get; set; }

    [Column("LocationCostCodeID")]
    public int? LocationCostCodeId { get; set; }

    [Column("BalanceSheetCodeID")]
    public int? BalanceSheetCodeId { get; set; }

    [Column("AssetCategoryID")]
    public int? AssetCategoryId { get; set; }

    [Column("ProjectCategoryID")]
    public int? ProjectCategoryId { get; set; }
    [Column("DepartmentID")]
    public int? DepartmentID { get; set; }

    public string? ShortDescription { get; set; }

    [Column(TypeName = "numeric(12, 2)")]
    public decimal? TotalCost { get; set; }

    [Column(TypeName = "numeric(12, 2)")]
    public decimal? AmountThisRequest { get; set; }

    [Column(TypeName = "numeric(12, 2)")]
    public decimal? PreviouslyAuthorized { get; set; }

    [Column(TypeName = "numeric(12, 2)")]
    public decimal? AmountInBudget { get; set; }

    [Column(TypeName = "numeric(12, 2)")]
    public decimal? WriteOffAmount { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ProjectStartupDate { get; set; }

    public string? ProjectManager { get; set; }

    public string? AmountIncludes { get; set; }

    public string? Motivation { get; set; }

    public string? ProjectScope { get; set; }

    public string? OutOfScope { get; set; }

    public short? CapexAuthorizationConfirm { get; set; }

    public short? CapexOutcome { get; set; }

    [Column("recStatus")]
    public short? RecStatus { get; set; }
    [Column("PaymentDate")]
    public DateTime? PaymentDate { get; set; }

    [ForeignKey("AssetCategoryId")]
    [InverseProperty("CapexForms")]
    public virtual AssetCategory? AssetCategory { get; set; }

    [ForeignKey("BalanceSheetCodeId")]
    [InverseProperty("CapexForms")]
    public virtual BalanceSheetCode? BalanceSheetCode { get; set; }

    [InverseProperty("FkCapex")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [InverseProperty("FkAcCapexFormNavigation")]
    public virtual ICollection<FkAttachmentsCapex> FkAttachmentsCapexes { get; set; } = new List<FkAttachmentsCapex>();

    [InverseProperty("FkKcCapexFormNavigation")]
    public virtual ICollection<FkKpicapex> FkKpicapexes { get; set; } = new List<FkKpicapex>();

    [InverseProperty("FkScCapexFormNavigation")]
    public virtual ICollection<FkSignatoriesCapex> FkSignatoriesCapexes { get; set; } = new List<FkSignatoriesCapex>();

    [ForeignKey("LocationCostCodeId")]
    [InverseProperty("CapexForms")]
    public virtual LocationCostCode? LocationCostCode { get; set; }

    [ForeignKey("ProjectCategoryId")]
    [InverseProperty("CapexForms")]
    public virtual ProjectCategory? ProjectCategory { get; set; }

    [InverseProperty("FkCapex")]
    public virtual ICollection<Risk> Risks { get; set; } = new List<Risk>();

    [ForeignKey("SiteId")]
    [InverseProperty("CapexForms")]
    public virtual Site? Site { get; set; }

    [NotMapped]
    public string OutcomeString { get; set; }
    [NotMapped]
    public string LegalEntityName { get; set; }
    [NotMapped]
    public string EmployeeNumber { get; set; }
}
