using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraftHits_CF.Controllers
{
    public class UpcomingController : Controller
    {
        // GET: Upcoming
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}