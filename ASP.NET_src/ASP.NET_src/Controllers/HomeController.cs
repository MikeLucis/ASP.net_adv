﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_src.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string user, string password)
        {
            if(user=="abc" && password=="123")
            {
                ViewBag.msg = ("Finish!!");
            }
            else
            {
                ViewBag.msg = ("Error!");
            }
            return View();
        }
    }
}