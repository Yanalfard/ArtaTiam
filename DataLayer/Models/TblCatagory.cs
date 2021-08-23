﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Models
{
    [Table("TblCatagory")]
    public partial class TblCatagory
    {
        public TblCatagory()
        {
            InverseParent = new HashSet<TblCatagory>();
            TblBlogs = new HashSet<TblBlog>();
        }

        [Key]
        public int CatagoryId { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [Required]
        [StringLength(256)]
        public string NameEn { get; set; }
        [Required]
        [StringLength(256)]
        public string NameAr { get; set; }
        public int? ParentId { get; set; }
        public bool IsOnFirstPage { get; set; }
        [StringLength(150)]
        public string Link { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty(nameof(TblCatagory.InverseParent))]
        public virtual TblCatagory Parent { get; set; }
        [InverseProperty(nameof(TblCatagory.Parent))]
        public virtual ICollection<TblCatagory> InverseParent { get; set; }
        [InverseProperty(nameof(TblBlog.Catagory))]
        public virtual ICollection<TblBlog> TblBlogs { get; set; }
    }
}
