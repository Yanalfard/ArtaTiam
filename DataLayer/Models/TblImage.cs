using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Models
{
    [Table("TblImage")]
    public partial class TblImage
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
