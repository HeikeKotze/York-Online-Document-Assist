using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models;

[Table("AccessType")]
public partial class AccessType
{
    [Key]
    [Column("AccessTypeID")]
    public int AccessTypeId { get; set; }

    [StringLength(50)]
    public string? AccessTypeName { get; set; }

}
