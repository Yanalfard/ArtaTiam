using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DataLayer.Models
{
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
