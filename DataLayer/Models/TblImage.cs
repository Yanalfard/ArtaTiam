﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataLayer.Models
{
    [Table("TblImage", Schema = "dbo")]
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
        [StringLength(150)]
        public string NameEn { get; set; }
        [StringLength(150)]
        public string DescriptionEn { get; set; }
        public int Status { get; set; }
        [StringLength(150)]
        public string NameAr { get; set; }
        [StringLength(150)]
        public string DescriptionAr { get; set; }
    }
}
