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
        public IActionResult Products(int id = 0)
        {
            List<TblBlog> list = _core.Blog.Get(orderBy: i => i.OrderByDescending(i => i.BlogId)).ToList();
            if (id != 0)
            {
                list = list.Where(i => i.CatagoryId == id || i.Catagory.ParentId == id).ToList();
            }
            return View(list);
        }
        public IActionResult EnProducts(int id = 0)
        {
            List<TblBlog> list = _core.Blog.Get(orderBy: i => i.OrderByDescending(i => i.BlogId)).ToList();
            if (id != 0)
            {
                list = list.Where(i => i.CatagoryId == id || i.Catagory.ParentId == id).ToList();
            }
            return View(list);
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
