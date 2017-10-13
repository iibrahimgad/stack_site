using Stack.DBContext;
using Stack.DBContext.Entities;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Stack.Controllers
{
    public class ArCategoriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        [Authorize]
        // GET: ArCategories
        public ActionResult Index()
        {
            return View();
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
    }
}