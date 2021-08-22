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
    public class CatagoryController : Controller
    {
        Core _core = new Core();
        public async Task<IActionResult> Index(int page = 1)
        {
            try
            {
                IEnumerable<TblCatagory> catagories = PagingList.Create(_core.Catagory.Get(c => c.ParentId == null), 10, page);
                return await Task.FromResult(View(catagories));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Create(int? Id)
        {
            try
            {
                return await Task.FromResult(ViewComponent("CreateCatagoryAdmin", new { Id = Id }));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblCatagory catagory)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (catagory.ParentId == null)
                    {
                        _core.Catagory.Add(catagory);
                        _core.Save();
                        return Redirect("/Admin/Catagory");
                    }
                    else
                    {
                        TblCatagory update = _core.Catagory.GetById(catagory.ParentId);
                        update.IsOnFirstPage = true;
                        _core.Catagory.Update(update);
                        _core.Catagory.Add(catagory);
                        _core.Save();
                        return await Task.FromResult(Redirect("/Admin/Catagory"));
                    }
                }
                return await Task.FromResult(PartialView("Create", catagory));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            try
            {
                return await Task.FromResult(ViewComponent("EditCatagoryAdmin", new { Id = Id }));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TblCatagory catagory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _core.Catagory.Update(catagory);
                    _core.Save();
                    return Redirect("/Admin/Catagory");
                }
                return await Task.FromResult(View(catagory));

            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }


        }

        [HttpGet]
        public async Task<IActionResult> ShowChilds(int Id)
        {
            try
            {
                return await Task.FromResult(ViewComponent("ShowChildsCatagoryAdmin", new { Id = Id }));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }

        //public string Delete(int id)
        //{
        //    if (_core.Catagory.GetById(id).InverseParent.Count() > 0 || _core.Catagory.GetById(id).TblProducts.Count() > 0)
        //    {
        //        return "false";
        //    }
        //    else
        //    {
        //        TblCatagory selectedCategory = _core.Catagory.GetById(id);
        //        if (selectedCategory.ParentId != null)
        //        {
        //            if (!_core.Catagory.Any(i => i.ParentId == selectedCategory.ParentId && i.CatagoryId != selectedCategory.CatagoryId))
        //            {
        //                TblCatagory update = _core.Catagory.GetById(selectedCategory.ParentId);
        //                update.IsOnFirstPage = false;
        //                _core.Catagory.Update(update);
        //                _core.Save();
        //            }
        //        }
        //        _core.Catagory.DeleteById(id);
        //        _core.Save();
        //        return "true";
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _core.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
