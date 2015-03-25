using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraftHits.Website.Controllers
{
    public class StaticContentController : Controller
    {
        // GET: StaticContent
     
        public ActionResult Legal()
        {
            return View();
        }
        public ActionResult Terms()
        {
            return View();
        }
    }
}