using DataLayer.Models;
using DataLayer.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArtaTiam.Controllers
{
    public class AccountController : Controller
    {
        private Core _core = new Core();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginVm login)
        {
            if (ModelState.IsValid)
            {
                TblUser user = _core.User.Get(i => i.TellNo == login.TellNo &&
                i.Password == login.Password).SingleOrDefault();
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.TellNo),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    return Redirect("/");
                }
                ModelState.AddModelError("TellNo", "کاربر مورد نظر یافت نشد");
            }
            return View(login);
        }
        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return await Task.FromResult(Redirect("/"));
            }
            catch
            {
                return await Task.FromResult(Redirect("Error"));
            }
        }
    }
}
