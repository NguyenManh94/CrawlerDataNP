using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMagazineProgramming.Controllers.ExcuteControlers.AdminControler
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["username"] == null || (string)(Session["username"]) == "")
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["id"] = null;
            Session["username"] = null;
            Session["name"] = null;
            Session["image"] = null;
            Session["permission"] = null;
            Session["timeEnd"] = null;
            Session["temp"] = "username" + null;
            return RedirectToAction("Index", "Login");
        }

        public ActionResult DanhSachTk()
        {
            if ((bool)Session["permission"] == true)
                return RedirectToAction("Index", "Accounts");
            else
            {
                TempData["checkAccout"] = "Tài khoản bạn hiện không có quyền này";
                return RedirectToAction("Index", "Admin", new { id = "Error" });
            }
        }

        public ActionResult ThemTk()
        {
            if ((bool)Session["permission"] == true)
                return RedirectToAction("Create", "Accounts");
            else
            {
                TempData["checkAccout"] = "Tài khoản bạn hiện không có quyền này";
                return RedirectToAction("Index", "Admin");
            }
        }

        public ActionResult Details()
        {
            var idTemp = Int32.Parse(Session["id"].ToString());
            return RedirectToAction("Details", "Accounts", new { id = idTemp });
        }
    }
}