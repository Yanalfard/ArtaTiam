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
    [PermissionChecker("admin")]
    public class GalleryController : Controller
    {
        Core _core = new Core();
        public IActionResult Image(int id, int page = 1)
        {
            List<TblImage> list = _core.Image.Get(i => i.Status == id).ToList();
            ViewBag.idImage = id;
            ViewBag.name = "";
            if (id == 1)
            {
                ViewBag.name = "عکس ها";
            }
            else if (id == 2)
            {
                ViewBag.name = "ویدیوها";
            }
            else if (id == 3)
            {
                ViewBag.name = "عکس بارگیری";
            }
            else if (id == 4)
            {
                ViewBag.name = "ویدیو بارگیری";
            }
            return View(PagingList.Create(list, 10, page));
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            try
            {
                ViewBag.name = "";
                if (id == 1)
                {
                    ViewBag.name = "عکس ";
                }
                else if (id == 2)
                {
                    ViewBag.name = "ویدیو";
                }
                else if (id == 3)
                {
                    ViewBag.name = "عکس بارگیری";
                }
                else if (id == 4)
                {
                    ViewBag.name = "ویدیو بارگیری";
                }
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
                NewSlider.NameAr = slider.NameAr;
                NewSlider.Description = slider.Description;
                NewSlider.DescriptionEn = slider.DescriptionEn;
                NewSlider.DescriptionAr = slider.DescriptionAr;
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
                return Redirect("/Admin/Gallery/Image/" + slider.Status);
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
                TblImage image = _core.Image.GetById(id);
                ViewBag.name = "";
                if (image.Status == 1)
                {
                    ViewBag.name = "عکس ";
                }
                else if (image.Status == 2)
                {
                    ViewBag.name = "ویدیو";
                }
                else if (image.Status == 3)
                {
                    ViewBag.name = "عکس بارگیری";
                }
                else if (image.Status == 4)
                {
                    ViewBag.name = "ویدیو بارگیری";
                }
                return await Task.FromResult(View(image));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(TblImage slider, IFormFile image)
        {
            try
            {


                TblImage NewSlider = _core.Image.GetById(slider.ImageId);
                NewSlider.Name = slider.Name;
                NewSlider.NameEn = slider.NameEn;
                NewSlider.NameAr = slider.NameAr;
                NewSlider.Description = slider.Description;
                NewSlider.DescriptionEn = slider.DescriptionEn;
                NewSlider.DescriptionAr = slider.DescriptionAr;
                if (image != null)
                {
                    try
                    {
                        var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Gallery", NewSlider.ImageUrl);
                        if (System.IO.File.Exists(deleteImagePath))
                        {
                            System.IO.File.Delete(deleteImagePath);
                        }
                    }
                    catch
                    {

                    }
                    NewSlider.ImageUrl = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    string savePath = Path.Combine(
                                               Directory.GetCurrentDirectory(), "wwwroot/Images/Gallery", NewSlider.ImageUrl
                                           );
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    };
                }

                _core.Image.Update(NewSlider);
                _core.Save();
                return Redirect("/Admin/Gallery/Image/" + slider.Status);

            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        public string RemoveSlider(int id)
        {
            TblImage slider = _core.Image.GetById(id);

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Gallery", slider.ImageUrl);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _core.Image.DeleteById(id);
            _core.Save();
            return "true";
        }

    }
}
