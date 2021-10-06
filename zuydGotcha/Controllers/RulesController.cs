using BUSS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Web.Mvc;
using zuydGotcha.Helper;

namespace zuydGotcha.Controllers
{
    public class RulesController : Controller
    {

        private RuleService RuleService = new RuleService();

        // GET: Rules
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Index()
        {
            var RuleList = RuleService.GetAllRule();

            return View(RuleList);
        }

        // GET: Rules/Details/5
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Details(int id)
        {
            var Model = RuleService.GetRuleById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // GET: Rules/Create
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rules/Create
        [HttpPost]
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Create(Rule Model)
        {
            if (ModelState.IsValid)
            {
                if (RuleService.CreateByModel(Model))
                {
                    RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(Model.Rule_Name), "Er is iets fout gegaan probeer het later op nieuw");
                }
            }

            return View(Model);
        }

        // GET: Rules/Edit/5
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Edit(int id)
        {
            var Model = RuleService.GetRuleById(id);
            if (Model == null)
            {
               RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: Rules/Edit/5
        [HttpPost]
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Edit(Rule Model)
        {
            if (ModelState.IsValid)
            {
                if (RuleService.EditByModel(Model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(Model.Rule_Name), "Er is iets fout gegaan probeer het later op nieuw");
                }
            }

            return View(Model);
        }

        // GET: Rules/Delete/5
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Delete(int id)
        {
            var Model = RuleService.GetRuleById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: Rules/Delete/5
        [HttpPost]
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Delete(Rule Model)
        {
            if (RuleService.DeleteByModel(Model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.Rule_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }

        //get Rules/copy/5
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Copy(int id)
        {
            var Model = RuleService.GetRuleById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        [HttpPost]
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Copy(Rule Model)
        {
            if (RuleService.CopyByModel(Model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.Rule_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }
    }
}
