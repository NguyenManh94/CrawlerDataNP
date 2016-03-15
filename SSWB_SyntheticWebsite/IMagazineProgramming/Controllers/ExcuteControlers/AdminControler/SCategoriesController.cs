using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMagazineProgramming.Models;

namespace IMagazineProgramming.Controllers.ExcuteControlers.AdminControler
{
    public class SCategoriesController : Controller
    {
        private SyntheticWebsiteEntities db = new SyntheticWebsiteEntities();

        public bool CheckLogin()
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
                return false;
            return true;
        }
        // GET: SCategories
        public ActionResult Index()
        {
            if (CheckLogin())
            {
                if ((bool)Session["permission"] == true)
                {
                    var sCategories = db.SCategories.Include(s => s.XCategory);
                    return View(sCategories.ToList());
                }
                else
                {
                    TempData["checkAccout"] = "Tài khoản bạn hiện không có quyền này";
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Login", new { id = "Chưa đăng nhập Error 1994" });
        }

        // GET: SCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (CheckLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SCategory sCategory = db.SCategories.Find(id);
                if (sCategory == null)
                {
                    return HttpNotFound();
                }
                return View(sCategory);
            }
            return RedirectToAction("Index", "Login", new { id = "Chưa đăng nhập Error 1994" });
        }

        // GET: SCategories/Create
        public ActionResult Create()
        {
            ViewBag.IdXCategory = new SelectList(db.XCategories, "Id", "NameXCategory");
            return View();
        }

        // POST: SCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameSCategory,Descibe,IdXCategory")] SCategory sCategory)
        {
            if (ModelState.IsValid)
            {
                db.SCategories.Add(sCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdXCategory = new SelectList(db.XCategories, "Id", "NameXCategory", sCategory.IdXCategory);
            return View(sCategory);
        }

        // GET: SCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCategory sCategory = db.SCategories.Find(id);
            if (sCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdXCategory = new SelectList(db.XCategories, "Id", "NameXCategory", sCategory.IdXCategory);
            return View(sCategory);
        }

        // POST: SCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameSCategory,Descibe,IdXCategory")] SCategory sCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdXCategory = new SelectList(db.XCategories, "Id", "NameXCategory", sCategory.IdXCategory);
            return View(sCategory);
        }

        // GET: SCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCategory sCategory = db.SCategories.Find(id);
            if (sCategory == null)
            {
                return HttpNotFound();
            }
            return View(sCategory);
        }

        // POST: SCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCategory sCategory = db.SCategories.Find(id);
            db.SCategories.Remove(sCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
