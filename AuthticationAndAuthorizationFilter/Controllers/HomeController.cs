﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthticationAndAuthorizationFilter.Filters;

namespace AuthticationAndAuthorizationFilter.Controllers
{
    [CustomAuthenticationFilter]
    public class HomeController : Controller
    {
        [CustomAuthorize("Normal","SuperAdmin", "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize("Admin", "SuperAdmin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [CustomAuthorize("SuperAdmin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "Un Authorized Page!";

            return View();
        }
    }
}