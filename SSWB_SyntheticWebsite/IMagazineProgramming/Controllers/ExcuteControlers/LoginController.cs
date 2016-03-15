using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMagazineProgramming.Models;

namespace IMagazineProgramming.Controllers.ExcuteControlers
{
    public class LoginController : Controller
    {
        private readonly SyntheticWebsiteEntities _db = new SyntheticWebsiteEntities();
        // GET: Login
        public ActionResult Index()
        {
            if (Session["username"] == null || (string)Session["username"] == "")
            {
                ViewBag.Err = "";
                return View();
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public ActionResult Index(string user, string pass)
        {
            var ec = new EncodeData();
            var decode = ec.Encode(pass.Trim());
            var row = _db.Accounts.SingleOrDefault(a => a.UserName.Trim().ToLower() == user.Trim().ToLower()
                                        && a.Password.Trim() == decode);
            if (row == null)
            {
                ViewBag.Err = "Đăng nhập thất bại- vui lòng kiểm tra lại Tài khoản hoặc Mật Khẩu !";
                return View();
            }
            else
            {
                if (row.Active == false)
                {
                    ViewBag.Err = "Tài khoản của bạn bị khóa vì 1 lý do nào đó !";
                    return View();
                }
                else
                {
                    Session["id"] = row.Id;
                    Session["username"] = row.UserName;
                    Session["name"] = row.Name;
                    Session["image"] = row.Image;
                    Session["permission"] = row.Permission;
                    Session["timeEnd"] = row.TimeEnd;
                    Session["temp"] = "username" + row.Id;
                    return RedirectToAction("Index", "Admin");
                }
            }
        }
    }
}