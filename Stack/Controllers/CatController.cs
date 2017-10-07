using Stack.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Stack.Controllers
{
    [RoutePrefix("cat")]
    public class CatController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [Route]
        public async Task<IHttpActionResult> GetCategories()
        {
            return Ok(await db.Categories.ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
