using ArtaTiam.Utilities;
using DataLayer.Models;
using DataLayer.ViewModels;
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
    public class GalleryController : Controller
    {
        Core _core = new Core();
        public IActionResult Image(int id, int page = 1)
        {
            List<TblImage> list = _core.Image.Get().ToList();
            ViewBag.idImage = id;
            return View(PagingList.Create(list, 10, page));
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            try
            {
                TblImage image = new TblImage();
                image.Status = id;
                return await Task.FromResult(View(image));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TblImage slider, IFormFile ImageUrl)
        {
            try
            {

                TblImage NewSlider = new TblImage();
                NewSlider.Name = slider.Name;
                NewSlider.NameEn = slider.NameEn;
                NewSlider.Description = slider.Description;
                NewSlider.DescriptionEn = slider.DescriptionEn;
                NewSlider.Status = slider.Status;
                if (ImageUrl != null)
                {
                    NewSlider.ImageUrl = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName);
                    string savePath = Path.Combine(
                                            Directory.GetCurrentDirectory(), "wwwroot/Images/Gallery", NewSlider.ImageUrl
                                        );
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(stream);
                    };
                }

                _core.Image.Add(NewSlider);
                _core.Save();
                return Redirect("/Admin/Gallery");
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
                return await Task.FromResult(View(_core.Image.GetById(id)));
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
