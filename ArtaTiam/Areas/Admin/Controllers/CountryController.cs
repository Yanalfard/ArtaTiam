﻿using ArtaTiam.Utilities;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace ArtaTiam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [PermissionChecker("admin")]
    public class CountryController : Controller
    {
        Core _core = new Core();
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            try
            {
                IEnumerable<TblBanner> AllSlider = PagingList.Create(_core.Baner.Get(i => i.IsSlider == false).OrderByDescending(bas => bas.BannerId), 10, page);
                return await Task.FromResult(View(AllSlider));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                return await Task.FromResult(ViewComponent("CreateCountryAdmin"));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TblBanner slider, IFormFile ImageUrl)
        {
            try
            {

                TblBanner NewSlider = new TblBanner();
                NewSlider.Name = slider.Name;
                NewSlider.NameAr = slider.NameAr;
                NewSlider.NameEn = slider.NameEn;
                NewSlider.Title = slider.Title;
                NewSlider.Link = slider.Link;
                NewSlider.IsSlider = false;
                if (ImageUrl != null && ImageUrl.IsImages() && ImageUrl.Length < 3000000)
                {
                    NewSlider.ImageUrl = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName);
                    string savePath = Path.Combine(
                                            Directory.GetCurrentDirectory(), "wwwroot/Images/Country", NewSlider.ImageUrl
                                        );
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(stream);
                    };
                }

                _core.Baner.Add(NewSlider);
                _core.Save();
                return Redirect("/Admin/Country");
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                return await Task.FromResult(ViewComponent("EditCountryAdmin", new { id = id }));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(TblBanner slider, IFormFile image)
        {
            try
            {


                TblBanner FirstSlider = _core.Baner.GetById(slider.BannerId);
                FirstSlider.Name = slider.Name;
                FirstSlider.Title = slider.Title;
                FirstSlider.IsSlider = false;
                FirstSlider.Link = slider.Link;
                FirstSlider.NameEn = slider.NameEn;
                FirstSlider.NameAr = slider.NameAr;
                if (image != null && image.IsImages() && image.Length < 3000000)
                {
                    try
                    {
                        var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Country", FirstSlider.ImageUrl);
                        if (System.IO.File.Exists(deleteImagePath))
                        {
                            System.IO.File.Delete(deleteImagePath);
                        }
                    }
                    catch
                    {

                    }
                    FirstSlider.ImageUrl = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    string savePath = Path.Combine(
                                               Directory.GetCurrentDirectory(), "wwwroot/Images/Country", FirstSlider.ImageUrl
                                           );
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    };
                }

                _core.Baner.Update(FirstSlider);
                _core.Save();
                return await Task.FromResult(Redirect("/Admin/Country"));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        public string RemoveSlider(int id)
        {
            TblBanner slider = _core.Baner.GetById(id);

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Country", slider.ImageUrl);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _core.Baner.DeleteById(id);
            _core.Save();
            return "true";
        }
    }
}
