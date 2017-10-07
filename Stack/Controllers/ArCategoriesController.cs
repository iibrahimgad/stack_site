using Stack.DBContext;
using Stack.DBContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Stack.Controllers
{
    public class ArCategoriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: ArCategories
        public ActionResult Index()
        {
            return View();
        }
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Category category = await db.Categories.Include()
        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(category);
        //}

    }
}