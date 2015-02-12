using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PriceComparisonTool.DAL;
using PriceComparisonTool.Models;
using PriceComparisonTool.ViewModels;

namespace PriceComparisonTool.Controllers
{
    public class PricesController : Controller
    {
        private AzureContext db = new AzureContext();

        // GET: Prices
        public ActionResult Index()
        {
            return View(db.Prices.ToList());
        }

        public ActionResult Index2()
        {
            var result = (from r in db.Prices
                         join p in db.Products on r.ProductID equals p.ID 
                         join s in db.Stores on r.StoreID equals s.ID
                        select new PriceViewModel
                         {
                             PriceID = r.PriceID,
                             StoreName = s.Name,
                             ProductName = p.Name,
                             FormattedAmount = p.AmountInUnits,
                             Price = r.Value,
                             Date = r.Date
                         }).Distinct();

            if (result == null)
            {
                return HttpNotFound();
            }
            return View((IEnumerable<PriceComparisonTool.ViewModels.PriceViewModel>)result);
        }

        // GET: Prices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // GET: Prices/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name");
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriceID,Value,ProductID,StoreID,Date")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(price);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", price.ProductID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", price.StoreID);
            return View(price);
        }

        // GET: Prices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", price.ProductID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", price.StoreID);
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PriceID,Value,ProductID,StoreID,Date")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", price.ProductID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", price.StoreID);
            return View(price);
        }

        // GET: Prices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Price price = db.Prices.Find(id);
            db.Prices.Remove(price);
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
