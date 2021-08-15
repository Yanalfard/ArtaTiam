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
    }
}
