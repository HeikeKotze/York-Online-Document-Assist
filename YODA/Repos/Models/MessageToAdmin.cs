using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("MessageToAdmin")]
    public class MessageToAdmin
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("MessageBody")]
        public string? MessageBody { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
        [Column("DateSent")]
        public DateTime? DateSent { get; set; }
        [Column("ReplyToSenderMessageBody")]
        public string? ReplyToSenderMessageBody { get; set; }
        [Column("ReplyDateSent")]
        public DateTime? ReplyDateSent { get; set; }
        [NotMapped]
        public string? DateString { get; set; }
        [NotMapped]
        public string? DateStringReply { get; set; }
        [NotMapped]
        public string? EmployeeName { get; set; }
    }
}
