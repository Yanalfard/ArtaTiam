using ArtaTiam.Utilities;
using DataLayer.Models;
using DataLayer.ViewModels;
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


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<TblConfig> configs = _core.Config.Get();
                ConfigVm config = new ConfigVm();
                config.Email = configs.Where(c => c.Key == "Email").Single().Value;
                config.Inista = configs.Where(c => c.Key == "Inista").Single().Value;
                config.TellHome1 = configs.Where(c => c.Key == "TellHome1").Single().Value;
                config.TellHome2 = configs.Where(c => c.Key == "TellHome2").Single().Value;
                config.TellMobile = configs.Where(c => c.Key == "TellMobile").Single().Value;
                config.Address = configs.Where(c => c.Key == "Address").Single().Value;
                config.Whatsapp = configs.Where(c => c.Key == "Whatsapp").Single().Value;
                config.TellModirAmel = configs.Where(c => c.Key == "TellModirAmel").Single().Value;
                config.TellRaisHyatModire = configs.Where(c => c.Key == "TellRaisHyatModire").Single().Value;
                config.TozihatShekatFooter = configs.Where(c => c.Key == "TozihatShekatFooter").Single().Value;
                return await Task.FromResult(View(config));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfigVm configVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<TblConfig> configs = _core.Config.Get();
                    TblConfig ConfigLinkEmail = configs.Where(c => c.Key == "Email").Single();
                    TblConfig ConfigLinkInista = configs.Where(c => c.Key == "Inista").Single();
                    TblConfig ConfigLinkTellMobile = configs.Where(c => c.Key == "TellMobile").Single();
                    TblConfig ConfigLinkAddress = configs.Where(c => c.Key == "Address").Single();
                    TblConfig ConfigLinkWhatsapp = configs.Where(c => c.Key == "Whatsapp").Single();
                    TblConfig ConfigLinkTozihatShekatFooter = configs.Where(c => c.Key == "TozihatShekatFooter").Single();
                    TblConfig ConfigLinkTellHome1 = configs.Where(c => c.Key == "TellHome1").Single();
                    TblConfig ConfigLinkTellHome2 = configs.Where(c => c.Key == "TellHome2").Single();
                    TblConfig ConfigLinkTellModirAmel = configs.Where(c => c.Key == "TellModirAmel").Single();
                    TblConfig ConfigLinkTellRaisHyatModire = configs.Where(c => c.Key == "TellRaisHyatModire").Single();


                    ConfigLinkEmail.Value = configVm.Email;
                    ConfigLinkInista.Value = configVm.Inista;
                    ConfigLinkTellMobile.Value = configVm.TellMobile;
                    ConfigLinkAddress.Value = configVm.Address;
                    ConfigLinkWhatsapp.Value = configVm.Whatsapp;
                    ConfigLinkTozihatShekatFooter.Value = configVm.TozihatShekatFooter;
                    ConfigLinkTellHome1.Value = configVm.TellHome1;
                    ConfigLinkTellHome2.Value = configVm.TellHome2;
                    ConfigLinkTellModirAmel.Value = configVm.TellModirAmel;
                    ConfigLinkTellRaisHyatModire.Value = configVm.TellRaisHyatModire;


                    _core.Config.Update(ConfigLinkEmail);
                    _core.Config.Update(ConfigLinkInista);
                    _core.Config.Update(ConfigLinkTellMobile);
                    _core.Config.Update(ConfigLinkAddress);
                    _core.Config.Update(ConfigLinkWhatsapp);
                    _core.Config.Update(ConfigLinkTozihatShekatFooter);
                    _core.Config.Update(ConfigLinkTellHome1);
                    _core.Config.Update(ConfigLinkTellHome2);
                    _core.Config.Update(ConfigLinkTellModirAmel);
                    _core.Config.Update(ConfigLinkTellRaisHyatModire);

                    _core.Save();
                    return await Task.FromResult(Redirect("/Admin/Config"));

                }
                return await Task.FromResult(View(configVm));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        public IActionResult DarnareModiamel()
        {
            TblConfig config = _core.Config.Get().FirstOrDefault(i => i.Key == "DarnareModiamelText");
            ViewBag.SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "DarnareModiamelImg").Value;
            return View(config);
        }

        [HttpPost]
        public async Task<IActionResult> DarnareModiamel(TblConfig config, IFormFile ImageUrl)
        {
            TblConfig SelectedConfigText = _core.Config.Get().FirstOrDefault(i => i.Key == "DarnareModiamelText");
            SelectedConfigText.Value = config.Value;


            TblConfig SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "DarnareModiamelImg");

            if (ImageUrl != null && ImageUrl.IsImages() && ImageUrl.Length < 3000000)
            {
                try
                {
                    var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/DarnareModiamelImg", SelectedConfigImg.Value);
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
                                        Directory.GetCurrentDirectory(), "wwwroot/Images/DarnareModiamelImg", SelectedConfigImg.Value
                                    );
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await ImageUrl.CopyToAsync(stream);
                };
            }
            _core.Config.Update(SelectedConfigText);
            _core.Config.Update(SelectedConfigImg);
            _core.Save();
            return RedirectToAction("DarnareModiamel");
        }



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

        public IActionResult DarbareMa()
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.DarbareMaImg = configs.Where(c => c.Key == "DarbareMaImg").Single().Value;
            config.DarbareMaText = configs.Where(c => c.Key == "DarbareMaText").Single().Value;
            //config.DarbareMaMavared = configs.Where(c => c.Key == "DarbareMaMavared").Single().Value;
            return View(config);
        }

        [HttpPost]
        public async Task<IActionResult> DarbareMa(ConfigVm configVm, IFormFile ImageUrl)
        {
            try
            {
                IEnumerable<TblConfig> configs = _core.Config.Get();
                TblConfig ConfigLinkDarbareMaImg = configs.Where(c => c.Key == "DarbareMaImg").Single();
                TblConfig ConfigLinkDarbareMaText = configs.Where(c => c.Key == "DarbareMaText").Single();
                //TblConfig ConfigLinkDarbareMaMavared = configs.Where(c => c.Key == "DarbareMaMavared").Single();
                if (ImageUrl != null && ImageUrl.IsImages() && ImageUrl.Length < 3000000)
                {
                    try
                    {
                        var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/DarbareMaImg", ConfigLinkDarbareMaImg.Value);
                        if (System.IO.File.Exists(deleteImagePath))
                        {
                            System.IO.File.Delete(deleteImagePath);
                        }
                    }
                    catch
                    {

                    }
                    ConfigLinkDarbareMaImg.Value = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName);
                    string savePath = Path.Combine(
                                            Directory.GetCurrentDirectory(), "wwwroot/Images/DarbareMaImg", ConfigLinkDarbareMaImg.Value
                                        );
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(stream);
                    };
                }

                ConfigLinkDarbareMaText.Value = configVm.DarbareMaText;
                //ConfigLinkDarbareMaMavared.Value = configVm.DarbareMaMavared;

                _core.Config.Update(ConfigLinkDarbareMaImg);
                _core.Config.Update(ConfigLinkDarbareMaText);
                //_core.Config.Update(ConfigLinkDarbareMaMavared);


                _core.Save();
                return await Task.FromResult(Redirect("/Admin/Config/DarbareMa"));

            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }
    }
}
