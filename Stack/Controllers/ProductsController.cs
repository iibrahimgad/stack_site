using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stack.DBContext;
using Stack.DBContext.Entities;
using System.IO;

namespace Stack.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ArName,Description,ArDescription,ImgSrc,CategoryId")] Product product, HttpPostedFileBase file)
        {
            var imgSrc = product.Name + ".jpg";
            var path = Path.Combine(Server.MapPath("~/images"), imgSrc);
            product.ImgSrc = imgSrc;
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                file.SaveAs(path);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ArName,Description,ArDescription,ImgSrc,CategoryId")] Product product, HttpPostedFileBase file)
        {
            var imgSrc = product.Name + ".jpg";
            var path = Path.Combine(Server.MapPath("~/images"), imgSrc);
            product.ImgSrc = imgSrc;
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                file.SaveAs(path);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Product product = await db.Products.FindAsync(id);
            var imgSrc = product.Name + ".jpg";
            db.Products.Remove(product);
            var path = Path.Combine(Server.MapPath("~/images"), imgSrc);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            await db.SaveChangesAsync();
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
