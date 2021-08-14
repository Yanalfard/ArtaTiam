﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.ViewModels
{
    public class ConfigVm
    {
        [Required(ErrorMessage = "لطفا لینک ایمیل را وارد کنید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا لینک تلگرم را وارد کنید")]
        public string Inista { get; set; }
        [Required(ErrorMessage = "لطفا شماره  را وارد کنید")]
        public string TellHome1 { get; set; }
        [Required(ErrorMessage = "لطفا شماره  را وارد کنید")]
        public string TellHome2 { get; set; }
        [Required(ErrorMessage = "لطفا موبایل را وارد کنید")]
        public string TellMobile { get; set; }
        [Required(ErrorMessage = "لطفا آدرس را وارد کنید")]
        public string Address { get; set; }
        [Required(ErrorMessage = "لطفا آدرس واتساب را وارد کنید")]
        public string Whatsapp { get; set; }
        [Required(ErrorMessage = "لطفا  توضیحات کوتاه در فوتر  را وارد کنید")]
        public string TozihatShekatFooter { get; set; }
        [Required(ErrorMessage = "لطفا شماره مدیرعامل را وارد کنید")]
        public string TellModirAmel { get; set; }
        [Required(ErrorMessage = "لطفا شماره رئیس هیئت مدیره  را وارد کنید")]
        public string TellRaisHyatModire { get; set; }
        public string DarbareMaText { get; set; }
        public string DarbareMaImg { get; set; }
        public string DarbareMaMavared { get; set; }

    }
}