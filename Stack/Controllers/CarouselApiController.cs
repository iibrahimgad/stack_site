using Stack.DBContext;
using Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stack.Controllers
{
    [RoutePrefix("carouselapi")]

    public class CarouselApiController : ApiController
    {
        private static List<Carousel> carouselList = CarouselService.CarouselList;
        [Route]
        public IHttpActionResult GetCarousel()
        {
            return Ok(carouselList);
        }
    }
}
