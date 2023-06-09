﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataLayer.Models
{
    [Table("TblUser", Schema = "dbo")]
    public partial class TblUser
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        public string TellNo { get; set; }
        [Required]
        [StringLength(64)]
        public string Password { get; set; }
    }
}
