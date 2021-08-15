using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Models
{
    [Table("TblBanner")]
    public partial class TblBanner
    {
        [Key]
        public int BannerId { get; set; }
        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Link { get; set; }
        public bool IsSlider { get; set; }
        [StringLength(150)]
        public string NameEn { get; set; }
    }
}
