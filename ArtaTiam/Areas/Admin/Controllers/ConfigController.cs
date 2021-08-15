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
                config.AddressEn = configs.Where(c => c.Key == "AddressEn").Single().Value;
                config.Whatsapp = configs.Where(c => c.Key == "Whatsapp").Single().Value;
                config.TellModirAmel = configs.Where(c => c.Key == "TellModirAmel").Single().Value;
                config.TellRaisHyatModire = configs.Where(c => c.Key == "TellRaisHyatModire").Single().Value;
                config.TozihatShekatFooter = configs.Where(c => c.Key == "TozihatShekatFooter").Single().Value;
                config.TozihatShekatFooterEn = configs.Where(c => c.Key == "TozihatShekatFooterEn").Single().Value;
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
                    TblConfig ConfigLinkAddressEn = configs.Where(c => c.Key == "AddressEn").Single();
                    TblConfig ConfigLinkTozihatShekatFooterEn = configs.Where(c => c.Key == "TozihatShekatFooterEn").Single();


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
                    ConfigLinkAddressEn.Value = configVm.AddressEn;
                    ConfigLinkTozihatShekatFooterEn.Value = configVm.TozihatShekatFooterEn;


                    _core.Config.Update(ConfigLinkTozihatShekatFooterEn);
                    _core.Config.Update(ConfigLinkAddressEn);
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
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.DarnareModiamelText = configs.Where(c => c.Key == "DarnareModiamelText").Single().Value;
            config.DarnareModiamelImg = configs.Where(c => c.Key == "DarnareModiamelImg").Single().Value;
            config.DarnareModiamelTextEn = configs.Where(c => c.Key == "DarnareModiamelTextEn").Single().Value;
            return View(config);
        }

        [HttpPost]
        public async Task<IActionResult> DarnareModiamel(ConfigVm configVm, IFormFile ImageUrl)
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            TblConfig DarnareModiamelText = configs.Where(c => c.Key == "DarnareModiamelText").Single();
            TblConfig SelectedConfigImg = configs.Where(c => c.Key == "DarnareModiamelImg").Single();
            TblConfig DarnareModiamelTextEn = configs.Where(c => c.Key == "DarnareModiamelTextEn").Single();
            DarnareModiamelText.Value = configVm.DarnareModiamelText;
            DarnareModiamelTextEn.Value = configVm.DarnareModiamelTextEn;

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
            _core.Config.Update(DarnareModiamelText);
            _core.Config.Update(SelectedConfigImg);
            _core.Config.Update(DarnareModiamelTextEn);
            _core.Save();


            return RedirectToAction("DarnareModiamel");
        }



        public IActionResult MoarefyeSherkat()
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.MoarefyeSherkatText = configs.Where(c => c.Key == "MoarefyeSherkatText").Single().Value;
            config.MoarefyeSherkatImg = configs.Where(c => c.Key == "MoarefyeSherkatImg").Single().Value;
            config.MoarefyeSherkatTextEn = configs.Where(c => c.Key == "MoarefyeSherkatTextEn").Single().Value;
            return View(config);
        }

        [HttpPost]
        public async Task<IActionResult> MoarefyeSherkat(ConfigVm configVm, IFormFile ImageUrl)
        {

            IEnumerable<TblConfig> configs = _core.Config.Get();
            TblConfig MoarefyeSherkatText = configs.Where(c => c.Key == "MoarefyeSherkatText").Single();
            TblConfig MoarefyeSherkatImg = configs.Where(c => c.Key == "MoarefyeSherkatImg").Single();
            TblConfig MoarefyeSherkatTextEn = configs.Where(c => c.Key == "MoarefyeSherkatTextEn").Single();
            MoarefyeSherkatText.Value = configVm.MoarefyeSherkatText;
            MoarefyeSherkatTextEn.Value = configVm.MoarefyeSherkatTextEn;

            if (ImageUrl != null && ImageUrl.IsImages() && ImageUrl.Length < 3000000)
            {
                try
                {
                    var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/MoarefyeSherkatImg", MoarefyeSherkatImg.Value);
                    if (System.IO.File.Exists(deleteImagePath))
                    {
                        System.IO.File.Delete(deleteImagePath);
                    }
                }
                catch
                {

                }
                MoarefyeSherkatImg.Value = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName);
                string savePath = Path.Combine(
                                        Directory.GetCurrentDirectory(), "wwwroot/Images/MoarefyeSherkatImg", MoarefyeSherkatImg.Value
                                    );
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await ImageUrl.CopyToAsync(stream);
                };
            }
            _core.Config.Update(MoarefyeSherkatText);
            _core.Config.Update(MoarefyeSherkatImg);
            _core.Config.Update(MoarefyeSherkatTextEn);
            _core.Save();
            return RedirectToAction("MoarefyeSherkat");
        }


        public IActionResult VideoSectionHome()
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.VideoSectionHomeText = configs.Where(c => c.Key == "VideoSectionHomeText").Single().Value;
            config.VideoSectionHomeImg = configs.Where(c => c.Key == "VideoSectionHomeImg").Single().Value;
            config.VideoSectionHomeTextEn = configs.Where(c => c.Key == "VideoSectionHomeTextEn").Single().Value;
            return View(config);

        }
        [HttpPost]
        public async Task<IActionResult> VideoSectionHome(ConfigVm configVm, IFormFile ImageUrl)
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            TblConfig VideoSectionHomeText = configs.Where(c => c.Key == "VideoSectionHomeText").Single();
            TblConfig VideoSectionHomeImg = configs.Where(c => c.Key == "VideoSectionHomeImg").Single();
            TblConfig VideoSectionHomeTextEn = configs.Where(c => c.Key == "VideoSectionHomeTextEn").Single();
            VideoSectionHomeText.Value = configVm.VideoSectionHomeText;
            VideoSectionHomeTextEn.Value = configVm.VideoSectionHomeTextEn;
            if (ImageUrl != null)
            {
                try
                {
                    var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/VideoSectionHome", VideoSectionHomeImg.Value);
                    if (System.IO.File.Exists(deleteImagePath))
                    {
                        System.IO.File.Delete(deleteImagePath);
                    }
                }
                catch
                {

                }
                VideoSectionHomeImg.Value = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName);
                string savePath = Path.Combine(
                                        Directory.GetCurrentDirectory(), "wwwroot/Images/VideoSectionHome", VideoSectionHomeImg.Value
                                    );
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await ImageUrl.CopyToAsync(stream);
                };
            }

            _core.Config.Update(VideoSectionHomeText);
            _core.Config.Update(VideoSectionHomeImg);
            _core.Config.Update(VideoSectionHomeTextEn);
            _core.Save();
        

            return RedirectToAction("VideoSectionHome");
        }

        public IActionResult DarbareMa()
        {
            IEnumerable<TblConfig> configs = _core.Config.Get();
            ConfigVm config = new ConfigVm();
            config.DarbareMaImg = configs.Where(c => c.Key == "DarbareMaImg").Single().Value;
            config.DarbareMaText = configs.Where(c => c.Key == "DarbareMaText").Single().Value;
            config.DarbareMaTextEn = configs.Where(c => c.Key == "DarbareMaTextEn").Single().Value;
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
                TblConfig ConfigLinkDarbareMaTextEn = configs.Where(c => c.Key == "DarbareMaTextEn").Single();
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
                ConfigLinkDarbareMaTextEn.Value = configVm.DarbareMaTextEn;
                //ConfigLinkDarbareMaMavared.Value = configVm.DarbareMaMavared;

                _core.Config.Update(ConfigLinkDarbareMaImg);
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
