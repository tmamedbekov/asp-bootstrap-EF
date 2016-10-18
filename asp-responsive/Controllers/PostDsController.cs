using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using asp_responsive.Models;

namespace asp_responsive.Controllers
{
    public class PostDsController : Controller
    {
        private TSearchDBEntities db = new TSearchDBEntities();

        // GET: PostDs
        public ActionResult Index()
        {
            var postDs = db.PostDs.Include(p => p.SearchType).Include(p => p.Source);
            return View(postDs.ToList());
        }

        // GET: PostDs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostD postD = db.PostDs.Find(id);
            if (postD == null)
            {
                return HttpNotFound();
            }
            return View(postD);
        }

        // GET: PostDs/Create
        public ActionResult Create()
        {
            ViewBag.SearchTypeId = new SelectList(db.SearchTypes, "Id", "Name");
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name");
            return View();
        }

        // POST: PostDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SourceId,SearchTypeId,UserId,UserName,Text,CreatedDateTime,Long,Lat,Location,Email,IsSelected")] PostD postD)
        {
            if (ModelState.IsValid)
            {
                db.PostDs.Add(postD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SearchTypeId = new SelectList(db.SearchTypes, "Id", "Name", postD.SearchTypeId);
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", postD.SourceId);
            return View(postD);
        }

        // GET: PostDs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostD postD = db.PostDs.Find(id);
            if (postD == null)
            {
                return HttpNotFound();
            }
            ViewBag.SearchTypeId = new SelectList(db.SearchTypes, "Id", "Name", postD.SearchTypeId);
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", postD.SourceId);
            return View(postD);
        }

        // POST: PostDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SourceId,SearchTypeId,UserId,UserName,Text,CreatedDateTime,Long,Lat,Location,Email,IsSelected")] PostD postD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SearchTypeId = new SelectList(db.SearchTypes, "Id", "Name", postD.SearchTypeId);
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", postD.SourceId);
            return View(postD);
        }

        // GET: PostDs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostD postD = db.PostDs.Find(id);
            if (postD == null)
            {
                return HttpNotFound();
            }
            return View(postD);
        }

        // POST: PostDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PostD postD = db.PostDs.Find(id);
            db.PostDs.Remove(postD);
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
