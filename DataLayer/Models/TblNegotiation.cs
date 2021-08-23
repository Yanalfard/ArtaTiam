using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Models
{
    public partial class TblNegotiation
    {
        [Key]
        public int NegotiationId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Product { get; set; }
        [StringLength(50)]
        public string FromCountry { get; set; }
        [StringLength(50)]
        public string Amount { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(20)]
        public string TellNo { get; set; }
        [StringLength(20)]
        public string PersonalityCode { get; set; }
    }
}
