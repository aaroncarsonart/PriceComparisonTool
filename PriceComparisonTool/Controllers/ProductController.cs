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
using PagedList;

namespace PriceComparisonTool.Controllers
{
    public class ProductController : Controller
    {
        private AzureContext db = new AzureContext();

        // GET: Product
        //public ActionResult Index()
        //{
        //    return View(db.Products.ToList());
        //}
        // GET: ShoppingList
        public ActionResult Index(int? id, int? productPage)
        {

            //var departments = db.Departments.Include(d => d.Administrator);
            //return View(departments.ToList());
            //go ahead you have con
            var viewModel = new ProductViewModel();
            viewModel.Products = (PagedList<Product>)db.Products
                .OrderBy(i => i.CategoryID)
                .ThenBy(i => i.Name).ToPagedList(productPage ?? 1, 10);

            Product sku = db.Products
                .Include(i => i.ProductSKU)
                .Where(i => i.ID == id)
                .SingleOrDefault();

            if (id != null)
            {
                ViewBag.ProductID = id.Value;
                //    viewModel.Prices = viewModel.Products.Where(i => i.ID == id.Value).Single()
                //        .Prices.OrderBy(i => i.Value);

                // 1.) get the current product.
                var p = db.Products
                    .Where(i => i.ID == id.Value)
                    .SingleOrDefault();

                // 2.) get the stores that have prices listed for this product.
                HashSet<Store> stores = new HashSet<Store>();
                foreach (Price r in p.Prices)
                {
                    stores.Add(r.Store);
                }

                // 3.) add the most recent price entry for each store
                List<Price> prices = new List<Price>();
                foreach (Store s in stores)
                {
                    prices.Add(s.Prices
                        .OrderByDescending(i => i.Date)
                        .FirstOrDefault());
                }

                // 4.) pass the prices to the viewModel
                viewModel.Prices = prices;
            }

            //5.) you're done!
            return View(viewModel);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,UPC,CategoryID,Amount,Units,IsGMO,IsCO,IsLG")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UPC,CategoryID,Amount,Units,IsGMO,IsCO,IsLG")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", product.CategoryID);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
