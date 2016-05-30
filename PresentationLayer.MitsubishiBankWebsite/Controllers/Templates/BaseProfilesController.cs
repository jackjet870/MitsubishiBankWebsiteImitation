using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.BaseCommon;
using Infrastructure.Data.MitsubishiBank.BankContexts;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Templates
{
    public class BaseProfilesController : Controller
    {
        private BankContext db = new BankContext();

        // GET: BaseProfiles
        public ActionResult Index()
        {
            var baseProfiles = db.BaseProfiles.Include(b => b.Customer);
            return View(baseProfiles.ToList());
        }

        // GET: BaseProfiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseProfile baseProfile = db.BaseProfiles.Find(id);
            if (baseProfile == null)
            {
                return HttpNotFound();
            }
            return View(baseProfile);
        }

        // GET: BaseProfiles/Create
        public ActionResult Create()
        {
            ViewBag.BaseProfileId = new SelectList(db.Customers, "CustomerId", "CustomerId");
            return View();
        }

        // POST: BaseProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BaseProfileId,FirstName,LastName,MiddleName,Phone,Email")] BaseProfile baseProfile)
        {
            if (ModelState.IsValid)
            {
                baseProfile.BaseProfileId = Guid.NewGuid();
                db.BaseProfiles.Add(baseProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BaseProfileId = new SelectList(db.Customers, "CustomerId", "CustomerId", baseProfile.BaseProfileId);
            return View(baseProfile);
        }

        // GET: BaseProfiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseProfile baseProfile = db.BaseProfiles.Find(id);
            if (baseProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.BaseProfileId = new SelectList(db.Customers, "CustomerId", "CustomerId", baseProfile.BaseProfileId);
            return View(baseProfile);
        }

        // POST: BaseProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BaseProfileId,FirstName,LastName,MiddleName,Phone,Email")] BaseProfile baseProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BaseProfileId = new SelectList(db.Customers, "CustomerId", "CustomerId", baseProfile.BaseProfileId);
            return View(baseProfile);
        }

        // GET: BaseProfiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseProfile baseProfile = db.BaseProfiles.Find(id);
            if (baseProfile == null)
            {
                return HttpNotFound();
            }
            return View(baseProfile);
        }

        // POST: BaseProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BaseProfile baseProfile = db.BaseProfiles.Find(id);
            db.BaseProfiles.Remove(baseProfile);
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
