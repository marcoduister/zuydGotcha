using BUSS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Web.Mvc;
using zuydGotcha.Helper;
using zuydGotcha.ViewModels.Shared;

namespace zuydGotcha.Controllers
{
    public class WordsController : Controller
    {

        private WordService WordService = new WordService();

        // GET: Words
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Index()
        {
            var wordsetList = WordService.GetAllWord();

            return View(wordsetList);
        }

        // GET: Words/Details/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Details(int id)
        {
            var Model = WordService.GetWordById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // GET: Words/Create
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Words/Create
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Create(Word Model)
        {
            if (ModelState.IsValid)
            {
                if (WordService.CreateByModel(Model))
                {
                    RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(Model.Word_Name), "Er is iets fout gegaan probeer het later op nieuw");
                }
            }

            return View(Model);
        }

        // GET: Words/Edit/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Edit(int id)
        {
            var Model = WordService.GetWordById(id);
            if (Model == null)
            {
               RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: Words/Edit/5
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Edit(Word Model)
        {
            if (ModelState.IsValid)
            {
                if (WordService.EditByModel(Model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(Model.Word_Name), "Er is iets fout gegaan probeer het later op nieuw");
                }
            }

            return View(Model);
        }

        // GET: Words/Delete/5
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Delete(int id)
        {
            var Model = WordService.GetWordById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: Words/Delete/5
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Delete(Word Model)
        {
            if (WordService.DeleteByModel(Model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.Word_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }

        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Copy(int id)
        {
            var Model = WordService.GetWordById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);

            //dit is voor het implementeren van modal vanplaats een hele view
            //ModalViewModel Model = new ModalViewModel();
            //Model.ObjId = id;
            //Model.Title = "WordSet Kopieren";
            //Model.Body = "Weet uw zekker dat uw deze wilt Kopieren!!!";

            //return PartialView("~/Views/Shared/_Modal.cshtml", Model);
        }

        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Copy(Word Model)
        {
            if (WordService.CopyByModel(Model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.Word_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }
    }
}
