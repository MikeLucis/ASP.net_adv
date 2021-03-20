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
    //实现验证控件-TODO
//    [HttpPost]
//    public ActionResult Edit(User user)
//    {
//        if (ModelState.)
//        {
//            return Content
//        }
//    }

    public class HomeController : Controller
    {
        //Home默认页视图函数
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            //使用@foreach-TODO
            if (username == "" && password == "")
            {
                ViewBag.msg = false;
            }
            else
            {
                if (username == "abc" && password == "123")
                {
                    ViewBag.msg = ("Finish!!");
                }
                else
                {
                    ViewBag.msg = ("Error!");
                } 
            }
            return View();
        }


        //Home注册页视图函数
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString))
            {
                string cmd = "Insert into Register(UserName, Email, PhoneNum, ConfimPassWords) Values(@UserName, @Email, @PhoneNum, @ConfimPassWords)";
                int i = con.Execute(cmd, user);
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


        //Home更改页视图函数
        [HttpGet]
        public ActionResult Update(int ID)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);

            string cmd = $"Select * From dbo.Register Where ID = {ID}";

            var info = con.Query<User>(cmd).SingleOrDefault();

            ViewData["UserInfo"] = info;

            return View();
        }

        [HttpPost]
        public ActionResult Update(int ID, User reg)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString))
            {
                string cmd = $"Update dbo.Register SET UserName = @UserName, Email = @Email, PhoneNum = @PhoneNum, ConfimPassWords = @ConfimPassWords Where (ID = {ID})";
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
            return View("UpdateResult");
        }
    }
}