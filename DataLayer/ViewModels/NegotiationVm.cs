using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.ViewModels
{
    public class NegotiationVm
    {
        [Key]
        public int NegotiationId { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "لطفا نام  را وارد کنید")]
        public string Name { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "لطفا نام محصول را وارد کنید")]
        public string Product { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "لطفا کشور  را وارد کنید")]
        public string FromCountry { get; set; }
        [Required(ErrorMessage = "لطفا مقدار  را وارد کنید")]
        public string Amount { get; set; }
        [StringLength(1000)]
        [Required(ErrorMessage = "لطفا توضیحات  را وارد کنید")]
        public string Description { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "لطفا شماره تلفن  را وارد کنید")]
        public string TellNo { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "لطفا کد ملی را وارد کنید")]
        public string PersonalityCode { get; set; }
    }



    public class NegotiationEnVm
    {
        [Key]
        public int NegotiationId { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Please Type Name")]
        public string Name { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Please Type Product")]
        public string Product { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Please Type FromCountry")]
        public string FromCountry { get; set; }
        [Required(ErrorMessage = "Please Type Amount")]
        public string Amount { get; set; }
        [StringLength(1000)]
        [Required(ErrorMessage = "Please Type Description")]
        public string Description { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Please Type Tell")]
        public string TellNo { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Please Type Personality Code")]
        public string PersonalityCode { get; set; }
    }
}
