using DataLayer.Models;
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
            return View();
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
            return View();
        }

        public IActionResult EnAboutCEO()
        {
            return View();
        }
    }
}
