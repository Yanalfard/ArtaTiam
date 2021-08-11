using ArtaTiam.Utilities;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtaTiam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ConfigController : Controller
    {
        Core _core = new Core();
        public IActionResult MoarefyeSherkat()
        {
            TblConfig config = _core.Config.Get().FirstOrDefault(i => i.Key == "MoarefyeSherkatText");
            ViewBag.SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "MoarefyeSherkatImg").Value;
            return View(config);
        }
      
        [HttpPost]
        public async Task<IActionResult> MoarefyeSherkat(TblConfig config, IFormFile ImageUrl)
        {
            TblConfig SelectedConfigText = _core.Config.Get().FirstOrDefault(i => i.Key == "MoarefyeSherkatText");
            SelectedConfigText.Value = config.Value;


            TblConfig SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "MoarefyeSherkatImg");

            if (ImageUrl != null && ImageUrl.IsImages() && ImageUrl.Length < 3000000)
            {
                try
                {
                    var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/MoarefyeSherkatImg", SelectedConfigImg.Value);
                    if (System.IO.File.Exists(deleteImagePath))
                    {
                        System.IO.File.Delete(deleteImagePath);
                    }
                }
                catch
                {

                }
                SelectedConfigImg.Value = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName);
                string savePath = Path.Combine(
                                        Directory.GetCurrentDirectory(), "wwwroot/Images/MoarefyeSherkatImg", SelectedConfigImg.Value
                                    );
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                   await ImageUrl.CopyToAsync(stream);
                };
            }
            _core.Config.Update(SelectedConfigText);
            _core.Config.Update(SelectedConfigImg);
            _core.Save();
            return RedirectToAction("MoarefyeSherkat");
        }


        public IActionResult VideoSectionHome()
        {
            TblConfig config = _core.Config.Get().FirstOrDefault(i => i.Key == "VideoSectionHomeText");
            ViewBag.SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "VideoSectionHomeImg").Value;
            return View(config);
        }
        [HttpPost]
        public async Task<IActionResult> VideoSectionHome(TblConfig config, IFormFile ImageUrl)
        {
            TblConfig SelectedConfigText = _core.Config.Get().FirstOrDefault(i => i.Key == "VideoSectionHomeText");
            SelectedConfigText.Value = config.Value;
            TblConfig SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "VideoSectionHomeImg");
            if (ImageUrl != null)
            {
                try
                {
                    var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/VideoSectionHome", SelectedConfigImg.Value);
                    if (System.IO.File.Exists(deleteImagePath))
                    {
                        System.IO.File.Delete(deleteImagePath);
                    }
                }
                catch
                {

                }
                SelectedConfigImg.Value = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName);
                string savePath = Path.Combine(
                                        Directory.GetCurrentDirectory(), "wwwroot/Images/VideoSectionHome", SelectedConfigImg.Value
                                    );
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await ImageUrl.CopyToAsync(stream);
                };
            }
            _core.Config.Update(SelectedConfigText);
            _core.Config.Update(SelectedConfigImg);
            _core.Save();
            return RedirectToAction("VideoSectionHome");
        }
    }
}
