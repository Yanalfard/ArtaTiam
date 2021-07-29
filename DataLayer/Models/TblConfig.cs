using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Models
{
    [Table("TblConfig")]
    public partial class TblConfig
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
        [StringLength(5)]
        public string Lan { get; set; }
    }
}
