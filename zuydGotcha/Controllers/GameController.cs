using BUSS.Service;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zuydGotcha.Helper;
using zuydGotcha.ViewModels.Access;

namespace zuydGotcha.Controllers
{
    public class GameController : Controller
    {
        private GameService _GameService = new GameService();

        // GET: Game
        public ActionResult Index()
        {
            var GameList = _GameService.GetAllGames();

            //dit is een voorbeeld van een automapper
            //deze checkt als model en viewmodel zelfde propertys hebben en plaats de waarde dan over van model naar viewmodel.
            //deze bestaat ook in viewmodel naar model
            //User newUser = new User()
            //{
            //    Email ="Marcoduister@hotmail.com"
            //};
            //LoginViewModel viewmodel = new LoginViewModel();

            //Mapper.Model(viewmodel, newUser);
            return View(GameList);
        }
        public ActionResult Create()
        {
            Game Model = new Game();
            return View(Model);
        }
        public ActionResult Edit(int id)
        {
            var Model = _GameService.GetGameById(id);

            return View(Model);
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}