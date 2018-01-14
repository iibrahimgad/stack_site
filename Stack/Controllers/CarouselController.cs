using Stack.DBContext;
using Stack.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Stack.Controllers
{
    [Authorize]
    public class CarouselController : Controller
    {
        private List<Carousel> carouselList = CarouselService.CarouselList;
        public ActionResult Index()
        {
            return View(carouselList);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carousel carousel = carouselList.FirstOrDefault(c => c.Id == id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,ImgSrc")] Carousel carousel, HttpPostedFileBase file)
        {
            var imgSrc = "slide" + carousel.Id + ".jpg";
            var path = Path.Combine(Server.MapPath("~/images"), imgSrc);
            carousel.ImgSrc = imgSrc;
            if (ModelState.IsValid)
            {
                carouselList.Add(carousel);
                file.SaveAs(path);

                return RedirectToAction("Index");
            }

            return View(carousel);
        }
    }
}
