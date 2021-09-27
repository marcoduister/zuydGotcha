using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace BUSS.Service
{
    public class GameService
    {
        private GotchaContext DBContext = new GotchaContext();

        public IEnumerable<Game> GetAllGames()
        {
            if (DBContext.Games.Any())
            {
                IEnumerable<Game> GameList = DBContext.Games.ToList();
                return GameList;
            }
            else
            {
                List<Game> Emty = new List<Game>();
                return Emty;
            }
        }
        public Game GetGameById(int Id)
        {
            if (DBContext.Games.Any(e =>e.Id == Id))
            {
                Game GameList = DBContext.Games.First(e =>e.Id == Id);
                return GameList;
            }
            else
            {
                return null;
            }
        }


        public List<RuleSet> GetRuleSetDrop()
        {
            int userId= int.Parse(HttpContext.Current.Session["UserID"].ToString());
            if (DBContext.RuleSets.Any(e => e.Maker_Id == userId))
            {
                List<RuleSet> List = DBContext.RuleSets.Where(e => e.Maker_Id == userId).ToList();
                return List;
            }
            else
            {
                return null;
            }
        }

        public List<WordSet> GetWordSetDrop()
        {
            int userId = int.Parse(HttpContext.Current.Session["UserID"].ToString());
            if (DBContext.WordSets.Any(e => e.Maker_Id == userId))
            {
                List<WordSet> List = DBContext.WordSets.Where(e => e.Maker_Id == userId).ToList();
                return List;
            }
            else
            {
                return null;
            }
        }

        public List<GameType> GetGameTypeDrop()
        {
            int userId = int.Parse(HttpContext.Current.Session["UserID"].ToString());
            if (DBContext.GameTypes.Any(e => e.Maker_Id == userId))
            {
                List<GameType> List = DBContext.GameTypes.Where(e => e.Maker_Id == userId).ToList();
                return List;
            }
            else
            {
                return null;
            }
        }
        public bool CreateByModel(Game model)
        {
            try
            {
                //List<Game> WordenList = new List<Word>();
                //foreach (var item in model.Word)
                //{
                //    WordenList.Add(DBContext.Words.AsNoTracking().First(e => e.Id == item.Id));
                //};
                //model.Word = WordenList;
                //model.Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString());

                //DBContext.WordSets.Add(model);
                //DBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool EditByModel(Game model)
        {
            try
            {
                Game CurrentGame = DBContext.Games.First(i => i.Id == model.Id);

                CurrentGame.GameType_Id = model.GameType_Id;
                CurrentGame.RuleSet_Id = model.RuleSet_Id;
                CurrentGame.WordSet_Id = model.WordSet_Id;
                CurrentGame.Location = model.Location;
                CurrentGame.Game_Name = model.Game_Name;
                CurrentGame.RandomWiner = model.RandomWiner;
                CurrentGame.BestKill = model.BestKill;
                CurrentGame.Archived = model.Archived;

                DBContext.SaveChanges();
                return true;

            }
            catch (Exception EX)
            {

                return false;
            }
        }
    }
}
