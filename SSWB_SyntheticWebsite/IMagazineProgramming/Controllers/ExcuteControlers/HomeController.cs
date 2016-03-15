using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMagazineProgramming.Controllers.ExcuteControlers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Get: Information Posts Content
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get: Information Content Main of Posts
        /// </summary>
        public ActionResult PostContent()
        {
            return View();
        }

        /// <summary>
        /// Get ViewImage 7 Categories
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewImage()
        {
            return View();
        }

        public ActionResult ViewInformation()
        {
            return View();
        }

        public ActionResult ViewHaveCate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchpost)
        {
            ViewBag.Data = searchpost;
            return View("SearchPost");
        }
        /// <summary>
        /// Serach Post in Imagazine
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchPost()
        {
            return View();
        }
    }
}