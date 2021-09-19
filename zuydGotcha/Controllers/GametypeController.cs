using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BUSS.Service;
using zuydGotcha.Helper;
using Models;
using zuydGotcha.ViewModels.Gametypes;

namespace zuydGotcha.Controllers
{
    public class GametypeController : Controller    
    {
        private GametypeService gametypeService = new GametypeService();

        public ActionResult Index()
        {
            var gametypeList = gametypeService.GetAllGametypes();

            return View(gametypeList);
        }

        // GET: Gametype
        public ActionResult AddGametype()
        {
            return View();
        }

        public ActionResult EditGametype()
        {
            return View();
        }
    }
}