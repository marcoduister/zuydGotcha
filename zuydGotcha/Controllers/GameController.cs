using BUSS.Service;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zuydGotcha.Helper;
using zuydGotcha.ViewModels.Access;
using zuydGotcha.ViewModels.User;

namespace zuydGotcha.Controllers
{
    public class GameController : Controller
    {
        private GameService _GameService = new GameService();
        private GameplayerContractService _GameplayerContractService = new GameplayerContractService();

        // GET: Game
        public ActionResult Index()
        {
            var GameList = _GameService.GetAllGames();

            return View(GameList);
        }
        [HttpGet]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Create()
        {
            Game Model = new Game();
            ViewData["RuleSetDrop"] = _GameService.GetRuleSetDrop().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.RuleSet_Name });
            ViewData["WordSetDrop"] = _GameService.GetWordSetDrop().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.WordSet_Name });
            ViewData["GameTypeDrop"] = _GameService.GetGameTypeDrop().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.GameType_Name });

            return View(Model);
        }

        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Create(Game Model)
        {
            if (ModelState.IsValid)
            {
                //if (WordService.EditByModel(Model))
                //{
                //    return RedirectToAction("Index");
                //}
                //else
                //{
                //    ModelState.AddModelError(nameof(Model.Word_Name), "Er is iets fout gegaan probeer het later op nieuw");
                //}
            }

            return View(Model);
        }

        [HttpGet]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Edit(int id)
        {
            var Model = _GameService.GetGameById(id);

            ViewData["RuleSetDrop"] = _GameService.GetRuleSetDrop().Select(a =>new SelectListItem{ Value = a.Id.ToString(), Text = a.RuleSet_Name});
            ViewData["WordSetDrop"] = _GameService.GetWordSetDrop().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.WordSet_Name });
            ViewData["GameTypeDrop"] = _GameService.GetGameTypeDrop().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.GameType_Name });

            return View(Model);
        }

        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Edit(Game Model)
        {
            if (ModelState.IsValid)
            {
                if (_GameService.EditByModel(Model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(Model.Game_Name), "Er is iets fout gegaan probeer het later op nieuw");
                }
            }

            return View(Model);
        }

        [HttpGet]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contract(int UserId, int GameId)
        {
            var Model = _GameplayerContractService.GetGameContractById(UserId,GameId);
            return View(Model);
        }


        [HttpGet]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Start(int id)
        {
            if (id != 0)
            {
                _GameplayerContractService.StartGame(id);
            }

            return RedirectToAction("Index");
        }

    }
}