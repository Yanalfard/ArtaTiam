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
    public class NegotiationController : Controller
    {
        Core _core = new Core();
        public async Task<IActionResult> Index(int page = 1)
        {
            try
            {
                IEnumerable<TblNegotiation> contactUs = PagingList.Create(_core.Negotiation.Get(orderBy: i => i.OrderByDescending(i => i.NegotiationId)), 40, page);
                return await Task.FromResult(View(contactUs));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }
        public async Task<IActionResult> Info(int id)
        {
            try
            {
                return await Task.FromResult(PartialView(_core.Negotiation.GetById(id)));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }
    }
}
