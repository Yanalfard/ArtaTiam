using ArtaTiam.Utilities;
using DataLayer.Models;
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
    public class UserController : Controller
    {
        Core _core = new Core();
        public IActionResult Index()
        {
            List<TblUser> list = _core.User.Get().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TblUser register)
        {
            if (ModelState.IsValid)
            {
                if (_core.User.Any(i => i.TellNo == register.TellNo))
                {
                    ModelState.AddModelError("TellNo", "شماره تلفن تکراریست");
                }
                else
                {
                    TblUser addUser = new TblUser();
                    addUser.Name = register.Name;
                    addUser.TellNo = register.TellNo;
                    addUser.Password =register.Password;

                    _core.User.Add(addUser);
                    _core.Save();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index");

                }
            }
            return View(register);
        }
        public ActionResult Edit(int id)
        {
            return View(_core.User.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(TblUser register)
        {
            if (ModelState.IsValid)
            {
                if (_core.User.Any(i => i.UserId != register.UserId && i.TellNo == register.TellNo))
                {
                    ModelState.AddModelError("TellNo", "شماره تلفن تکراریست");
                }
                else
                {
                    TblUser updateUser = _core.User.GetById(register.UserId);
                    updateUser.Name = register.Name;
                    updateUser.TellNo = register.TellNo;
                    updateUser.Password = register.Password;
                    _core.User.Update(updateUser);
                    _core.Save();
                    return RedirectToAction("Index");

                }
            }
            return View(register);
        }

        public string Delete(int id)
        {
            try
            {
                TblUser deleteUser = _core.User.GetById(id);
                if (deleteUser != null)
                {

                    _core.User.Delete(deleteUser);
                    _core.Save();
                    return "true";
                }
                return "false";

            }
            catch (Exception)
            {
                return "false";
            }

        }

    }
}
