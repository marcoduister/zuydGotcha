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
    public class GametypeController : Controller
    {

        private GameTypeService GameTypeService = new GameTypeService();

        // GET: GameType
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Index()
        {
            var GameList = GameTypeService.GetAllGameType();

            return View(GameList);
        }

        // GET: GameType/Details/5
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Details(int id)
        {
            var Model = GameTypeService.GetGameTypeById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // GET: GameType/Create
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameType/Create
        [HttpPost]
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Create(GameType Model)
        {
            if (ModelState.IsValid)
            {
                if (GameTypeService.CreateByModel(Model))
                {
                    RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(Model.GameType_Name), "Er is iets fout gegaan probeer het later op nieuw");
                }
            }

            return View(Model);
        }

        // GET: GameType/Edit/5
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Edit(int id)
        {
            var Model = GameTypeService.GetGameTypeById(id);
            if (Model == null)
            {
               RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: GameType/Edit/5
        [HttpPost]
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Edit(GameType Model)
        {
            if (ModelState.IsValid)
            {
                if (GameTypeService.EditByModel(Model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(Model.GameType_Name), "Er is iets fout gegaan probeer het later op nieuw");
                }
            }

            return View(Model);
        }

        // GET: GameType/Delete/5
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Delete(int id)
        {
            var Model = GameTypeService.GetGameTypeById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        // POST: Words/Delete/5
        [HttpPost]
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Delete(GameType Model)
        {
            if (GameTypeService.DeleteByModel(Model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.GameType_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }

        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Copy(int id)
        {
            var Model = GameTypeService.GetGameTypeById(id);
            if (Model == null)
            {
                RedirectToAction("Index");
            }

            return View(Model);
        }

        [HttpPost]
        [CheckAuth(Roles = "Gamemaster,Admin")]
        public ActionResult Copy(GameType Model)
        {
            if (GameTypeService.CopyByModel(Model))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(nameof(Model.GameType_Name), "Er is iets fout gegaan probeer het later op nieuw");
            }
            return View();
        }
    }
}
