using ArtaTiam.Utilities;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtaTiam.ViewComponents.View.VideoSectionHome
{
    public class VideoSectionHomeComponent : ViewComponent
    {
        private Core _core = new Core();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            TblConfig config = _core.Config.Get().FirstOrDefault(i => i.Key == "VideoSectionHomeText");
            ViewBag.SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "VideoSectionHomeImg").Value;
            return await Task.FromResult((IViewComponentResult)View("~/Views/Shared/Components/VideoSectionHomeComponent" +
                "/VideoSectionHomeComponent.cshtml", config));
        }
    }
}
