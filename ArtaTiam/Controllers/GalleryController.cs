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
    public class GalleryController : Controller
    {
        private Core _core = new Core();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View(_core.Image.Get());
        }

        public IActionResult EnGallery()
        {
            return View(_core.Image.Get());
        }
    }
}
