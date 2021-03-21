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
    //todo: 控件验证
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
        /// <summary>
        /// 请求返回页
        /// </summary>
        /// <returns>View.Index</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 提交返回页(添加确认信息)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>View.Index + ViewBag.msg</returns>
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (username == "" && password == "")
            {
                ViewBag.msg = null;
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
        /// <summary>
        /// 请求返回页
        /// </summary>
        /// <returns>View.Register</returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        /// <summary>
        /// 提交返回页(向表插入数据并添加确认信息)
        /// </summary>
        /// <param name="user"></param>
        /// <returns>View.Register + SQL-Insert + ViewBag.msg</returns>
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
                    ViewBag.flag = false;
                }
            }
                return View("RegisterResult");
        }


        //Home更改页视图函数
        /// <summary>
        /// 请求返回页(表单显示数据)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>View.Update + SQL-Select + ViewData</returns>
        [HttpGet]
        public ActionResult Update(int ID)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);

            string cmd = $"Select * From dbo.Register Where ID = {ID}";

            var info = con.Query<User>(cmd).SingleOrDefault();

            ViewData["UserInfo"] = info;

            return View("Update");
        }

        /// <summary>
        /// 提交返回页(向表更新数据并添加确认信息)
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="reg"></param>
        /// <returns>View.UpdateResult + SQL-Update + ViewBag</returns>
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
                    ViewBag.flag = false;
                }
            }
            return View("UpdateResult");
        }
    }
}