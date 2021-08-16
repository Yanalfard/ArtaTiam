using DataLayer.Models;
using DataLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtaTiam.Controllers
{
    public class ContactController : Controller
    {
        private Core _core = new Core();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cooperation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cooperation(NegotiationVm negotiation)
        {
            if (ModelState.IsValid)
            {
                TblNegotiation addNegotiation1 = new TblNegotiation();
                addNegotiation1.FromCountry = negotiation.FromCountry;
                addNegotiation1.Name = negotiation.Name;
                addNegotiation1.Product = negotiation.Product;
                addNegotiation1.TellNo = negotiation.TellNo;
                addNegotiation1.Description = negotiation.Description;
                addNegotiation1.Amount = negotiation.Amount;
                _core.Negotiation.Add(addNegotiation1);
                _core.Save();
                return Redirect("/Contact/Cooperation?SendForm=true");
            }
            return View(negotiation);
        }
        public IActionResult ContactUs()
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.Email = configs.Where(c => c.Key == "Email").Single().Value;
            config.Address = configs.Where(c => c.Key == "Address").Single().Value;
            config.Inista = configs.Where(c => c.Key == "Inista").Single().Value;
            config.TellHome1 = configs.Where(c => c.Key == "TellHome1").Single().Value;
            config.TellHome2 = configs.Where(c => c.Key == "TellHome2").Single().Value;
            config.Whatsapp = configs.Where(c => c.Key == "Whatsapp").Single().Value;
            config.TellMobile = configs.Where(c => c.Key == "TellMobile").Single().Value;
            config.TozihatShekatFooter = configs.Where(c => c.Key == "TozihatShekatFooter").Single().Value;
            config.TellModirAmel = configs.Where(c => c.Key == "TellModirAmel").Single().Value;
            config.TellRaisHyatModire = configs.Where(c => c.Key == "TellRaisHyatModire").Single().Value;
            return View(config);
        }

        public IActionResult EnCooperation()
        {
            return View();
        }
        public IActionResult EnContactUs()
        {
            return View();
        }
    }
}
