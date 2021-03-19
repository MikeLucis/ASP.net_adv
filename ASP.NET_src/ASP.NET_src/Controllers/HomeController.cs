using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using ASP.NET_src.Models;

namespace ASP.NET_src.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if(username=="abc" && password=="123")
            {
                ViewBag.msg = ("Finish!!");
            }
            else
            {
                ViewBag.msg = ("Error!");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterInfo reg)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString))
            {
                string cmd = "Insert into Register(UserName, Email, PhoneNum, Password1) Values(@UserName, @Email, @PhoneNum, @Password1)";
                int i = con.Execute(cmd, reg);
                if (i > 0)
                {
                    ViewBag.msg = "Finish !!";
                }
                else
                {
                    ViewBag.msg = "Error !!";
                }

                
            }
                return View();
        }
    }
}