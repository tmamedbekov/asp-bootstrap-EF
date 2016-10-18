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
    public class TweetController : Controller
    {
        private TSearchDBEntities db = new TSearchDBEntities();

        // GET: Tweet
        public ActionResult Index()
        {
            var masters = db.Masters.Include(m => m.SearchType).Include(m => m.Source);
            return View(masters.ToList());
        }

        // GET: Tweet/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Masters.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // GET: Tweet/Create
        public ActionResult Create()
        {
            ViewBag.SearchTypeId = new SelectList(db.SearchTypes, "Id", "Name");
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name");
            return View();
        }

        // POST: Tweet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SourceId,SearchTypeId,UserId,UserName,Text,CreatedDateTime,Long,Lat,Location,Email,InsertDateTime,Processed")] Master master)
        {
            if (ModelState.IsValid)
            {
                db.Masters.Add(master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SearchTypeId = new SelectList(db.SearchTypes, "Id", "Name", master.SearchTypeId);
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", master.SourceId);
            return View(master);
        }

        // GET: Tweet/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Masters.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            ViewBag.SearchTypeId = new SelectList(db.SearchTypes, "Id", "Name", master.SearchTypeId);
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", master.SourceId);
            return View(master);
        }

        // POST: Tweet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SourceId,SearchTypeId,UserId,UserName,Text,CreatedDateTime,Long,Lat,Location,Email,InsertDateTime,Processed")] Master master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SearchTypeId = new SelectList(db.SearchTypes, "Id", "Name", master.SearchTypeId);
            ViewBag.SourceId = new SelectList(db.Sources, "Id", "Name", master.SourceId);
            return View(master);
        }

        // GET: Tweet/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Masters.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // POST: Tweet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Master master = db.Masters.Find(id);
            db.Masters.Remove(master);
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
