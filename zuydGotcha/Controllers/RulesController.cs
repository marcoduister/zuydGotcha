using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BUSS.Service;
using zuydGotcha.Helper;
using Models;

namespace zuydGotcha.Controllers
{
    public class RulesController : Controller
    {
        private RuleService ruleService = new RuleService();

        // GET: Rules
        public ActionResult AddRule()
        {
            return View();
        }

        public ActionResult EditRule()
        {
            return View();
        }

        public ActionResult OverviewRulesets()
        {
            var rulesetList = ruleService.GetAllRulesets();

            return View(rulesetList);
        }

        public ActionResult AddRuleset()
        {
            return View();
        }

        public ActionResult EditRuleset()
        {
            return View();
        }
    }
}