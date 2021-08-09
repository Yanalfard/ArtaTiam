using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Services.Services;

namespace NimaProj.ViewComponents.Admin.Country
{
    public class EditCountryAdmin : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            Core core = new Core();
            return await Task.FromResult((IViewComponentResult)View("/Areas/Admin/Views/Country/Components/Edit.cshtml", core.Baner.GetById(id)));
        }
    }
}
