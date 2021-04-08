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
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);

            string cmd = $"Select * From dbo.TeacherRegister";

            var info = con.Query<TeacherUser>(cmd);

            return View(info);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeacherUser user)
        {
            if (ModelState.IsValid)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString))
                {
                    string cmd = "Insert into TeacherRegister(TeacherNumber, TeacherName, Password, Gender, ProfessionalTitle, Email, QQ, Telephone) Values(@TeacherNumber, @TeacherName, @Password, @Gender, @ProfessionalTitle, @Email, @QQ, @Telephone)";
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
                return View("Create");
            }
            else
            {
                ModelState.AddModelError("", "The infomation not fund");
                return View("Create");
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);

            string cmd = $"Select * From dbo.TeacherRegister Where ID = {ID}";

            var info = con.Query<TeacherUser>(cmd).SingleOrDefault();

            return View(info);
        }

        [HttpPost]
        public ActionResult Edit(int ID, TeacherUser reg)
        {
            if (ModelState.IsValid)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString))
                {
                    string cmd = $"Update dbo.TeacherRegister SET TeacherNumber = @TeacherNumber, TeacherName = @TeacherName, Password = @Password, Gender = @Gender, ProfessionalTitle = @ProfessionalTitle, Email = @Email, QQ = @QQ, Telephone = @Telephone Where (ID = {ID})";
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
                return View("Edit");
            }
            else
            {
                ModelState.AddModelError("", "The infomation not fund");
                return View("Edit");
            }
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
    }
}