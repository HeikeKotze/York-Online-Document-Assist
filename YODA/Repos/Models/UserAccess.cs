using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("Access")]
    public class UserAccess
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ModuleID")]
        public int ModuleID { get; set; }
        [Column("UserID")]
        public int UserID { get;set; }
        [Column("AccessTypeID")]
        public int AccessTypeID { get; set; }
        [Column("recStatus")]
        public int recStatus { get; set; }
    }
}
