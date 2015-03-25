using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraftHits.Website.Controllers
{
    public class LiveController : Controller
    {
        // GET: Live
    [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}