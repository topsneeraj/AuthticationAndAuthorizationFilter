using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthticationAndAuthorizationFilter.Models;
namespace AuthticationAndAuthorizationFilter.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            if(ModelState.IsValid)
            {
                using (var dbcontext = new ApplicationContext())
                {
                    User user = dbcontext.Users.Where(u => u.UserId == model.UserId && u.Password == model.Password).FirstOrDefault();

                    if(user!=null)
                    {
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = user.UserId;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        ModelState.AddModelError("", "invalid User Name and Password");
                        return View(model);

                    }

                }

            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["UserName"] = string.Empty;
            Session["UserId"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }
    }
}