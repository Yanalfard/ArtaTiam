using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer
{
    [Table("TblContactUs", Schema = "dbo")]
    public partial class TblContactU
    {
        [Key]
        public int ContactUsId { get; set; }
        [StringLength(150)]
        public string To { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(20)]
        public string TellNo { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }
    }
}
