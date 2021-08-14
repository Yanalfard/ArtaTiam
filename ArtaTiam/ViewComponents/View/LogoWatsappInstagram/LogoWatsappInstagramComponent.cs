using ArtaTiam.Utilities;
using DataLayer.Models;
using DataLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtaTiam.ViewComponents.View.LogoWatsappInstagram
{
    public class LogoWatsappInstagramComponent : ViewComponent
    {
        private Core _core = new Core();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.Inista = configs.Where(c => c.Key == "Inista").Single().Value;
            config.Whatsapp = configs.Where(c => c.Key == "Whatsapp").Single().Value;
            return await Task.FromResult((IViewComponentResult)View("~/Views/Shared/Components/LogoWatsappInstagramComponent" +
                "/LogoWatsappInstagramComponent.cshtml", config));
        }
    }
}



