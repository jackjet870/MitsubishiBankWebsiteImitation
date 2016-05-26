using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.MitsubishiBankWebsite.Models;
using PresentationLayer.MitsubishiBankWebsite.Models.Bank;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Templates
{
    public class TEMPLATE_BANK_SCAFFOLD_Controller : Controller
    {
        private TemplateContext db = new TemplateContext();

        // GET: TEMPLATE_BANK_SCAFFOLD_
        public ActionResult Index()
        {
            return View(db.BankCreateBaseModels.ToList());
        }

        // GET: TEMPLATE_BANK_SCAFFOLD_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankCreateBaseModel bankCreateBaseModel = db.BankCreateBaseModels.Find(id);
            if (bankCreateBaseModel == null)
            {
                return HttpNotFound();
            }
            return View(bankCreateBaseModel);
        }

        // GET: TEMPLATE_BANK_SCAFFOLD_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TEMPLATE_BANK_SCAFFOLD_/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,Country,Location,AccountName,AccountCode,TotalFinanceAmount")] BankCreateBaseModel bankCreateBaseModel)
        {
            if (ModelState.IsValid)
            {
                db.BankCreateBaseModels.Add(bankCreateBaseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bankCreateBaseModel);
        }

        // GET: TEMPLATE_BANK_SCAFFOLD_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankCreateBaseModel bankCreateBaseModel = db.BankCreateBaseModels.Find(id);
            if (bankCreateBaseModel == null)
            {
                return HttpNotFound();
            }
            return View(bankCreateBaseModel);
        }

        // POST: TEMPLATE_BANK_SCAFFOLD_/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,Country,Location,AccountName,AccountCode,TotalFinanceAmount")] BankCreateBaseModel bankCreateBaseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankCreateBaseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankCreateBaseModel);
        }

        // GET: TEMPLATE_BANK_SCAFFOLD_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankCreateBaseModel bankCreateBaseModel = db.BankCreateBaseModels.Find(id);
            if (bankCreateBaseModel == null)
            {
                return HttpNotFound();
            }
            return View(bankCreateBaseModel);
        }

        // POST: TEMPLATE_BANK_SCAFFOLD_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankCreateBaseModel bankCreateBaseModel = db.BankCreateBaseModels.Find(id);
            db.BankCreateBaseModels.Remove(bankCreateBaseModel);
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
