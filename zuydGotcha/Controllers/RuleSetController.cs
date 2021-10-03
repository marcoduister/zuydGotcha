using BUSS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Web.Mvc;
using zuydGotcha.ViewModels.RuleSet;
using zuydGotcha.Helper;

namespace zuydGotcha.Controllers
{
    public class RuleSetController : Controller
    {

        private RuleSetService RuleSetService = new RuleSetService();

        // GET: RuleSets
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Index()
        {
            var RulesetList = RuleSetService.GetAllRuleSets();


            return View(RulesetList);
        }

        // GET: RuleSet/Details/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Details(int id)
        {
            var Model = RuleSetService.GetRuleSetById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // GET: RuleSet/Create
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Create()
        {
            RuleSetViewModel model = new RuleSetViewModel();
            ICollection<Rule> Dropdown = RuleSetService.GetAllMyRules();
            if (Dropdown != null)
            {
                model.DropdownRuleList = Dropdown;
                return View(model);
                
            }
            return RedirectToAction("Index");
        }

        // POST: RuleSet/Create
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Create(RuleSetViewModel Model)
        {
            if (ModelState.IsValid)
            {

                RuleSet NewModel = new RuleSet();

                foreach (var item in Model.SelectedIds) { NewModel.Rule.Add(new Rule { Id = item }); }

                Mapper.Model(NewModel, Model);

                if (RuleSetService.CreateByModel(NewModel))
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError(nameof(Model.RuleSet_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }

            return View(Model);
        }

        // GET: RuleSet/Edit/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Edit(int id)
        {
            RuleSetViewModel NewModel = new RuleSetViewModel();
            RuleSet Model = RuleSetService.GetRuleSetById(id);
            
            ICollection<Rule> Dropdown = RuleSetService.GetAllMyRules();
            Mapper.Model(NewModel, Model);
            if (Dropdown != null)
            {
                NewModel.DropdownRuleList = Dropdown;
                NewModel.SelectedIds = Model.Rule.Select(e => e.Id).ToArray();
                return View(NewModel);
            }

            return View(NewModel);
        }

        // POST: RuleSet/Edit/5
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Edit(RuleSetViewModel Model)
        {
            if (ModelState.IsValid)
            {
                RuleSet NewModel = new RuleSet();
                if (Model.SelectedIds !=null)
                {
                    foreach (var item in Model.SelectedIds) { NewModel.Rule.Add(new Rule { Id = item }); }
                }

                Mapper.Model(NewModel, Model);
                if (RuleSetService.EditByModel(NewModel))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(Model.RuleSet_Name), "Er is iets fout gegaan probeer het later op nieuw");
                }
            }
            return View(Model);
        }

        // GET: RuleSet/Delete/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Delete(int id)
        {
            var Model = RuleSetService.GetRuleSetById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: RuleSet/Delete/5
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Delete(RuleSet Model)
        {
            if (RuleSetService.DeleteByModel(Model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.RuleSet_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }

        // Get: RuleSet/Copy/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Copy(int id)
        {

            var Model = RuleSetService.GetRuleSetById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: RuleSet/Copy/5
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Copy(RuleSet Model)
        {
            if (RuleSetService.CopyByModel(Model.Id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.RuleSet_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }

    }
}
