using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zuydGotcha.Controllers
{
    public class WordsController : Controller
    {
        // GET: Words
        public ActionResult AddWord()
        {
            return View();
        }

        public ActionResult EditWord()
        {
            return View();
        }

        public ActionResult OverviewWordsets()
        {
            return View();
        }

        public ActionResult AddWordset()
        {
            return View();
        }

        public ActionResult EditWordset()
        {
            return View();
        }
    }
}