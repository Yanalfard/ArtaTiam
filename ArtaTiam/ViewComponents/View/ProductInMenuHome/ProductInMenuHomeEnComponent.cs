using ArtaTiam.Utilities;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ArtaTiam.ViewComponents.View.ProductInMenuHome
{
    public class ProductInMenuHomeEnComponent : ViewComponent
    {
        private Core _core = new Core();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("~/Views/Shared/Components/ProductInMenuHomeComponent" +
                "/ProductInMenuHomeEnComponent.cshtml", _core.Catagory.Get(i => i.Parent == null)));
        }
    }
}