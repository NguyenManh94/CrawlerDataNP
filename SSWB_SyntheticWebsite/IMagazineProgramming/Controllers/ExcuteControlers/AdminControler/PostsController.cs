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
    public class PostsController : Controller
    {
        private SyntheticWebsiteEntities db = new SyntheticWebsiteEntities();

        public bool CheckLogin()
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
                return false;
            return true;
        }
        // GET: Posts
        public ActionResult Index()
        {
            if (CheckLogin())
            {
                var posts = db.Posts.Include(p => p.Account).Include(p => p.SCategory);
                return View(posts.ToList());
            }
            else return RedirectToAction("Index", "Login");
        }

        public ActionResult Index2()
        {
            if (CheckLogin())
            {
                var posts = db.Posts.Include(p => p.Account).Include(p => p.SCategory);
                return View(posts.ToList());
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (CheckLogin())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Post post = db.Posts.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                return View(post);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.IdAccount = new SelectList(db.Accounts, "Id", "UserName");
            ViewBag.IdSCategory = new SelectList(db.SCategories, "Id", "NameSCategory");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdAccount,IdSCategory,Title,Image,Summary,ContentView,DatePost,Active,Viewed")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAccount = new SelectList(db.Accounts, "Id", "UserName", post.IdAccount);
            ViewBag.IdSCategory = new SelectList(db.SCategories, "Id", "NameSCategory", post.IdSCategory);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAccount = new SelectList(db.Accounts, "Id", "UserName", post.IdAccount);
            ViewBag.IdSCategory = new SelectList(db.SCategories, "Id", "NameSCategory", post.IdSCategory);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdAccount,IdSCategory,Title,Image,Summary,ContentView,DatePost,Active,Viewed")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAccount = new SelectList(db.Accounts, "Id", "UserName", post.IdAccount);
            ViewBag.IdSCategory = new SelectList(db.SCategories, "Id", "NameSCategory", post.IdSCategory);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
