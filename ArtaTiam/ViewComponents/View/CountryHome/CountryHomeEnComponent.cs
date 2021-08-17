using ArtaTiam.Utilities;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ArtaTiam.ViewComponents.View.CountryHome
{
    public class CountryHomeEnComponent : ViewComponent
    {
        private Core _core = new Core();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<TblBanner> list = _core.Baner.Get(i => i.IsSlider == false).ToList();
            list.ShuffleList();
            return await Task.FromResult((IViewComponentResult)View("~/Views/Shared/Components/CountryHomeComponent/CountryHomeEnComponent.cshtml", list));
        }
    }
}
