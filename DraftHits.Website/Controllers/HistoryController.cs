﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DraftHits.Website.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
          [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}