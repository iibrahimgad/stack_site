using Stack.DBContext;
using Stack.DBContext.Entities;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Stack.Controllers
{
    public class CategoriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        [Authorize]
        // GET: Categories
        public async Task<ActionResult> Index()
        {
            return View(await db.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [Authorize]
        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ArName,ImgSrc")] Category category, HttpPostedFileBase file)
        {
            var imgSrc = category.Name + ".jpg";
            var path = Path.Combine(Server.MapPath("~/images"), imgSrc);
            category.ImgSrc = imgSrc;
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                file.SaveAs(path);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        [Authorize]
        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ArName,ImgSrc")] Category category, HttpPostedFileBase file)
        {
            var imgSrc = category.Name + ".jpg";
            var path = Path.Combine(Server.MapPath("~/images"), imgSrc);
            category.ImgSrc = imgSrc;
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                file.SaveAs(path);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Authorize]
        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            var path = Path.Combine(Server.MapPath("~/images"), category.ImgSrc);
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
