using ArtaTiam.Utilities;
using DataLayer.Models;
using DataLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtaTiam.ViewComponents.View.Footer
{
    public class FooterEnComponent : ViewComponent
    {
        private Core _core = new Core();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.Email = configs.Where(c => c.Key == "Email").Single().Value;
            config.Inista = configs.Where(c => c.Key == "Inista").Single().Value;
            config.TellHome1 = configs.Where(c => c.Key == "TellHome1").Single().Value;
            config.TellHome2 = configs.Where(c => c.Key == "TellHome2").Single().Value;
            config.TellMobile = configs.Where(c => c.Key == "TellMobile").Single().Value;
            config.AddressEn = configs.Where(c => c.Key == "AddressEn").Single().Value;
            config.Whatsapp = configs.Where(c => c.Key == "Whatsapp").Single().Value;
            config.TozihatShekatFooterEn = configs.Where(c => c.Key == "TozihatShekatFooterEn").Single().Value;

            return await Task.FromResult((IViewComponentResult)View("~/Views/Shared/Components/FooterComponent" +
                "/FooterEnComponent.cshtml", config));
        }
    }
}