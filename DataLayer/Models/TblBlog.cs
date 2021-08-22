using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Models
{
    [Table("TblBlog")]
    public partial class TblBlog
    {
        [Key]
        public int BlogId { get; set; }
        [StringLength(200)]
        public string MainImage { get; set; }
        [Required(ErrorMessage = "عنوان پست را وارد کنید")]
        [StringLength(200, ErrorMessage = "عنوان کوتاه تری وارد کنید")]
        public string Title { get; set; }
        [Required(ErrorMessage = "لطفا توضبحات  را وارد کنید")]
        [StringLength(500, ErrorMessage = "توضیحات کوتاه پست را وارد کنید")]
        public string Description { get; set; }
        [Required(ErrorMessage = "توضیحات کامل پست را وارد کنید")]
        public string BodyHtml { get; set; }
        [Required(ErrorMessage = "عنوان انگلیسی پست را وارد کنید")]
        [StringLength(200, ErrorMessage = "عنوان کوتاه تری وارد کنید")]
        public string TitleEn { get; set; }
        [Required(ErrorMessage = "لطفا توضبحات انگلیسی را وارد کنید")]
        [StringLength(500, ErrorMessage = "توضیحات کوتاه پست را وارد کنید")]
        public string DescriptionEn { get; set; }
        [Required(ErrorMessage = "توضیحات کامل انگلیسی پست را وارد کنید")]
        public string BodyHtmlEn { get; set; }
        [Required(ErrorMessage = "عنوان عربی پست را وارد کنید")]
        [StringLength(200, ErrorMessage = "عنوان کوتاه تری وارد کنید")]
        public string TitleAr { get; set; }
        [Required(ErrorMessage = "لطفا توضبحات عربی را وارد کنید")]
        [StringLength(500, ErrorMessage = "توضیحات کوتاه پست را وارد کنید")]
        public string DescriptionAr { get; set; }
        [Required(ErrorMessage = "توضیحات کامل عربی پست را وارد کنید")]
        public string BodyHtmlAr { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }
    }
}
