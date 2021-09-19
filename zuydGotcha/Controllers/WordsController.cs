using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BUSS.Service;
using zuydGotcha.Helper;
using Models;
using zuydGotcha.ViewModels.Words;

namespace zuydGotcha.Controllers
{
    public class WordsController : Controller
    {
        private WordService wordService = new WordService();

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
            var wordsetList = wordService.GetAllWordsets();

            return View(wordsetList);
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