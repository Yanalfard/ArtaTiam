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
    public class AboutController : Controller
    {
        private Core _core = new Core();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.DarbareMaImg = configs.Where(c => c.Key == "DarbareMaImg").Single().Value;
            config.DarbareMaText = configs.Where(c => c.Key == "DarbareMaText").Single().Value;
            return View(config);
        }
        public IActionResult AboutCEO()
        {
            TblConfig config = _core.Config.Get().FirstOrDefault(i => i.Key == "DarnareModiamelText");
            ViewBag.SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "DarnareModiamelImg").Value;
            ViewBag.SelectedWhatsapp = _core.Config.Get().FirstOrDefault(i => i.Key == "Whatsapp").Value;
            return View(config);
        }

        public IActionResult EnAboutUs()
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.DarbareMaImg = configs.Where(c => c.Key == "DarbareMaImg").Single().Value;
            config.DarbareMaTextEn = configs.Where(c => c.Key == "DarbareMaTextEn").Single().Value;
            return View(config);
        }

        public IActionResult EnAboutCEO()
        {
            TblConfig config = _core.Config.Get().FirstOrDefault(i => i.Key == "DarnareModiamelTextEn");
            ViewBag.SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "DarnareModiamelImg").Value;
            ViewBag.SelectedWhatsapp = _core.Config.Get().FirstOrDefault(i => i.Key == "Whatsapp").Value;
            return View(config);
        }
    }
}
