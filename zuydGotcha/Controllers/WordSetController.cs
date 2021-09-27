using BUSS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Web.Mvc;
using zuydGotcha.ViewModels.WordSet;
using zuydGotcha.Helper;

namespace zuydGotcha.Controllers
{
    public class WordSetController : Controller
    {

        private WordSetService WordSetService = new WordSetService();

        // GET: WordSets
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Index()
        {
            var wordsetList = WordSetService.GetAllWordSets();


            return View(wordsetList);
        }

        // GET: WordSet/Details/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Details(int id)
        {
            var Model = WordSetService.GetWordSetById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // GET: WordSet/Create
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Create()
        {
            WordenSetViewModel model = new WordenSetViewModel();
            ICollection<Word> Dropdown = WordSetService.GetAllMyWords();
            if (Dropdown != null)
            {
                model.DropdownWordList = Dropdown;
                return View(model);
                
            }
            return RedirectToAction("Index");
        }

        // POST: WordSet/Create
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Create(WordenSetViewModel Model)
        {
            if (ModelState.IsValid)
            {

                WordSet NewModel = new WordSet();

                foreach (var item in Model.SelectedIds) { NewModel.Word.Add(new Word { Id = item }); }

                Mapper.Model(NewModel, Model);

                if (WordSetService.CreateByModel(NewModel))
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError(nameof(Model.WordSet_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }

            return View(Model);
        }

        // GET: WordSet/Edit/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Edit(int id)
        {
            WordenSetViewModel NewModel = new WordenSetViewModel();
            WordSet Model = WordSetService.GetWordSetById(id);
            
            ICollection<Word> Dropdown = WordSetService.GetAllMyWords();
            Mapper.Model(NewModel, Model);
            if (Dropdown != null)
            {
                NewModel.DropdownWordList = Dropdown;
                NewModel.SelectedIds = Model.Word.Select(e => e.Id).ToArray();
                return View(NewModel);

            }

            return View(NewModel);
        }

        // POST: WordSet/Edit/5
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Edit(WordenSetViewModel Model)
        {
            if (ModelState.IsValid)
            {
                WordSet NewModel = new WordSet();
                if (Model.SelectedIds !=null)
                {
                    foreach (var item in Model.SelectedIds) { NewModel.Word.Add(new Word { Id = item }); }
                }

                Mapper.Model(NewModel, Model);
                if (WordSetService.EditByModel(NewModel))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(Model.WordSet_Name), "Er is iets fout gegaan probeer het later op nieuw");
                }
            }
            return View(Model);
        }

        // GET: WordSet/Delete/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Delete(int id)
        {
            var Model = WordSetService.GetWordSetById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: WordSet/Delete/5
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Delete(WordSet Model)
        {
            if (WordSetService.DeleteByModel(Model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.WordSet_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }

        // Get: WordSet/Copy/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Copy(int id)
        {

            var Model = WordSetService.GetWordSetById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: WordSet/Copy/5
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Copy(WordSet Model)
        {
            if (WordSetService.CopyByModel(Model.Id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.WordSet_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }

    }
}
