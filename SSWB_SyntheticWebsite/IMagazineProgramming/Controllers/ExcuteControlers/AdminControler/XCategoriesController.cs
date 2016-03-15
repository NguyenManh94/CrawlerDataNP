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
    public class XCategoriesController : Controller
    {
        private SyntheticWebsiteEntities db = new SyntheticWebsiteEntities();

        // GET: XCategories
        public ActionResult Index()
        {
            if ((bool)Session["permission"] == true)
            {
                return View(db.XCategories.ToList());
            }
            else
            {
                TempData["checkAccout"] = "Tài khoản bạn hiện không có quyền này";
                return RedirectToAction("Index", "Admin");
            }
        }

        // GET: XCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XCategory xCategory = db.XCategories.Find(id);
            if (xCategory == null)
            {
                return HttpNotFound();
            }
            return View(xCategory);
        }

        // GET: XCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: XCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameXCategory,Descibe")] XCategory xCategory)
        {
            if (ModelState.IsValid)
            {
                db.XCategories.Add(xCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(xCategory);
        }

        // GET: XCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XCategory xCategory = db.XCategories.Find(id);
            if (xCategory == null)
            {
                return HttpNotFound();
            }
            return View(xCategory);
        }

        // POST: XCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameXCategory,Descibe")] XCategory xCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(xCategory);
        }

        // GET: XCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XCategory xCategory = db.XCategories.Find(id);
            if (xCategory == null)
            {
                return HttpNotFound();
            }
            return View(xCategory);
        }

        // POST: XCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            XCategory xCategory = db.XCategories.Find(id);
            db.XCategories.Remove(xCategory);
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
