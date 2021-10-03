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
                if (_GameService.CreateByModel(Model))
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
        [CheckAuth(Roles = "Admin,GameMasters,Player")]
        public ActionResult Details(int id)
        {
            var model =_GameService.GetGameById(id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult ContractPartial(int id)
        {
            int userid = int.Parse(Session["UserID"].ToString());
            var Model = _GameplayerContractService.GetGameContractById(userid, id);
            if (Model != null)
            {
                return PartialView("Contract", Model);

            }
            return PartialView("Contract", Model);
           

        }

        [HttpGet]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Delete(int id)
        {
            var model = _GameService.GetGameById(id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [CheckAuth(Roles = "Admin,GameMasters")]
        public ActionResult Delete(Game Model)
        {
            if (_GameService.Archive(Model.Id))
            {
                return RedirectToAction("Index");
                
            }
            return View(Model);
        }

        [HttpGet]
        public ActionResult Contract(int UserId, int GameId)
        {
            if (UserId != 0 && GameId != 0)
            {
                var Model = _GameplayerContractService.GetGameContractById(UserId, GameId);
                return View(Model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Join(int id)
        {
            if (id != 0)
            {
                if (_GameplayerContractService.JoinGameById(id))
                {
                    return RedirectToAction("Details", "Game", new { id = id });
                }
            }
            return RedirectToAction("Index");
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
        [HttpGet]
        [CheckAuth(Roles = "Player")]
        public ActionResult Eliminate(int id)
        {

            //dit is nog niet geimplementeerd
            if (id != 0)
            {
                _GameplayerContractService.EliminateByGamePlayerId(id);
            }

            return RedirectToAction("Index");
        }
        

    }
}