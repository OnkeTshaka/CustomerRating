using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ratings.Models;

namespace ratings.Controllers
{
    public class ArticlesCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArticlesComments
        public ActionResult Index()
        {
            return View(db.ArticlesComments.ToList());
        }

        // GET: ArticlesComments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesComment articlesComment = db.ArticlesComments.Find(id);
            if (articlesComment == null)
            {
                return HttpNotFound();
            }
            return View(articlesComment);
        }

        // GET: ArticlesComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticlesComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Comments,ThisDateTime,ArticleId,Rating")] ArticlesComment articlesComment)
        {
            if (ModelState.IsValid)
            {
                articlesComment.CommentId = Guid.NewGuid();
                db.ArticlesComments.Add(articlesComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articlesComment);
        }

        // GET: ArticlesComments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesComment articlesComment = db.ArticlesComments.Find(id);
            if (articlesComment == null)
            {
                return HttpNotFound();
            }
            return View(articlesComment);
        }

        // POST: ArticlesComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Comments,ThisDateTime,ArticleId,Rating")] ArticlesComment articlesComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articlesComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articlesComment);
        }

        // GET: ArticlesComments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesComment articlesComment = db.ArticlesComments.Find(id);
            if (articlesComment == null)
            {
                return HttpNotFound();
            }
            return View(articlesComment);
        }

        // POST: ArticlesComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ArticlesComment articlesComment = db.ArticlesComments.Find(id);
            db.ArticlesComments.Remove(articlesComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FormCollection form)
        {
            var comment = form["Comment"].ToString();
            var articleId = int.Parse(form["ArticleId"]);
            var rating = int.Parse(form["Rating"]);

            ArticlesComment artComment = new ArticlesComment()
            {
                ArticleId = articleId,
                Comments = comment,
                Rating = rating,
                ThisDateTime = DateTime.Now
            };

            db.ArticlesComments.Add(artComment);
            db.SaveChanges();

            return RedirectToAction("Details", "Articles", new { id = articleId });
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
