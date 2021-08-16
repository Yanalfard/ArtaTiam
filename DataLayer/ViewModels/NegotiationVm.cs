﻿using System;
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
    }
}