using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Models2
{
    [Table("TblBlog", Schema = "dbo")]
    public partial class TblBlog
    {
        [Key]
        public int BlogId { get; set; }
        [StringLength(200)]
        public string MainImage { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public string BodyHtml { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
        [Required]
        [StringLength(200)]
        public string TitleEn { get; set; }
        [StringLength(500)]
        public string DescriptionEn { get; set; }
        [Required]
        public string BodyHtmlEn { get; set; }
        [Required]
        [StringLength(200)]
        public string TitleAr { get; set; }
        [StringLength(500)]
        public string DescriptionAr { get; set; }
        [Required]
        public string BodyHtmlAr { get; set; }
        public int CatagoryId { get; set; }

        [ForeignKey(nameof(CatagoryId))]
        [InverseProperty(nameof(Models.TblCatagory.TblBlogs))]
        public virtual Models.TblCatagory Catagory { get; set; }
    }
}
