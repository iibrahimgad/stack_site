using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Stack.DBContext.Entities;
using Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ArIndex()
        {
            // var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            // var authManager = HttpContext.GetOwinContext().Authentication;
            //var res =  userManager.Create(new AppUser("Admin"), "admin!1");
            return View();
        }



        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            var login = new LoginViewModel()
            {
                Username = fc["Username"],
                Password = fc["Password"]
            };
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            AppUser user = userManager.Find(login.Username, login.Password);
            if (user != null)
            {
                var ident = userManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, ident);
                return Redirect(Url.Action("Index", "categories"));
            }
            ViewBag.Error = "Invalid Username or Password";
            return View(login);
        }

        public ActionResult Change()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Change(FormCollection fc)
        {
            var model = new ChangePassword()
            {
                CurrentPassowrd = fc["CurrentPassword"],
                NewPassword = fc["NewPassword"]
            };
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            var username = User.Identity.GetUserName();
            var userId = User.Identity.GetUserId();
            var res = userManager.ChangePassword(userId, model.CurrentPassowrd, model.NewPassword);
            ViewBag.Msg = res;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Logout(FormCollection fc)
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index");
        }

    }
}