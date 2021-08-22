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
    public class HomeController : Controller
    {
        private Core _core = new Core();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }

        public IActionResult EnIndex()
        {
            return View();
        }

        public IActionResult EnServices()
        {
            return View();
        }
    }
}
