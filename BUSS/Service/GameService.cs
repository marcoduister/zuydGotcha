using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
