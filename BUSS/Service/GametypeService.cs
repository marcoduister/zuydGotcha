using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Data;
using Models;

namespace BUSS.Service
{
    public class GameTypeService
    {
        private GotchaContext DBContext = new GotchaContext();

        public IEnumerable<GameType> GetAllGameType()
        {
            if (DBContext.GameTypes.Any())
            {
                IEnumerable<GameType> GameTypeList = DBContext.GameTypes.ToList();
                return GameTypeList;
            }
            else
            {
                List<GameType> emty = new List<GameType>();
                return emty;
            }
        }

        public bool CreateByModel(GameType model)
        {
            try
            {
                model.Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                DBContext.GameTypes.Add(model);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool EditByModel(GameType model)
        {
            try
            {
                var gameType = DBContext.GameTypes.SingleOrDefault(e => e.Id == model.Id);
                if (gameType != null)
                {
                    gameType.GameType_Name = model.GameType_Name;
                    gameType.GameType_Description = model.GameType_Description;
                    DBContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public GameType GetGameTypeById(int id)
        {

            if (DBContext.GameTypes.Any(e => e.Id == id))
            {
                GameType gameType = DBContext.GameTypes.First(e => e.Id == id);
                return gameType;
            }
            else
            {
                return null;
            }
            
        }

        public bool DeleteByModel(GameType Model)
        {
            try
            {
                if (DBContext.GameTypes.Any(e => e.Id == Model.Id))
                {

                    DBContext.Entry(Model).State = EntityState.Deleted;
                    DBContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool CopyByModel(GameType Model)
        {
            try
            {
                if (DBContext.GameTypes.Any(e => e.Id == Model.Id))
                {
                    GameType CopyGameType = new GameType()
                    {
                        GameType_Name = Model.GameType_Name,
                        GameType_Description = Model.GameType_Description,
                        Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString())
                    };

                    DBContext.GameTypes.Add(CopyGameType);
                    DBContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
