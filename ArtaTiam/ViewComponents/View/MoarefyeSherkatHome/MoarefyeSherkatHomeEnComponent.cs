using ArtaTiam.Utilities;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtaTiam.ViewComponents.View.MoarefyeSherkatHome
{
    public class MoarefyeSherkatHomeEnComponent : ViewComponent
    {
        private Core _core = new Core();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            TblConfig config = _core.Config.Get().FirstOrDefault(i => i.Key == "MoarefyeSherkatTextEn");
            ViewBag.SelectedConfigImg = _core.Config.Get().FirstOrDefault(i => i.Key == "MoarefyeSherkatImg").Value;
            return await Task.FromResult((IViewComponentResult)View("~/Views/Shared/Components/MoarefyeSherkatHomeComponent" +
                "/MoarefyeSherkatHomeEnComponent.cshtml", config));
        }
    }
}
