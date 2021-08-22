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
    public class ProductController : Controller
    {
        private Core _core = new Core();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View(_core.Blog.Get(orderBy: i => i.OrderByDescending(i => i.BlogId)));
        }
        public IActionResult EnProducts()
        {
            return View(_core.Blog.Get(orderBy: i => i.OrderByDescending(i => i.BlogId)));
        }
        public IActionResult Product(int id)
        {
            return View(_core.Blog.GetById(id));
        }
        public IActionResult EnProduct(int id)
        {
            return View(_core.Blog.GetById(id));
        }
    }
}
