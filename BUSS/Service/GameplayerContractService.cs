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
    public class GameplayerContractService 
    {
        private GotchaContext DBContext = new GotchaContext();

        public List<Contract> GetGameContractById(int UserId,int GameId)
        {

            if (DBContext.GamePlayers.Any(e => e.User_Id == UserId))
            {
                List<Contract> player = DBContext.Contracts.Include(e=>e.GamePlayer_Eliminate).AsNoTracking().Where(e => e.Eliminator_Id == UserId && e.Game_Id == GameId).ToList();
                foreach (var item in player)
                {
                    if (item.Word_Id == null)
                    {
                        item.Word = new Word();
                    }
                }
                return player;
            }
            else
            {
                return null;
            }
        }

        public bool StartGame(int Id)
        {

            if (DBContext.Games.Any(e => e.Id == Id))
            {
                Game currentGame = DBContext.Games.First(e => e.Id == Id);
                currentGame.Game_Start = DateTime.Now;

                List<GamePlayer> players = DBContext.GamePlayers.Where(e => e.Game_Id == Id).OrderBy(r => Guid.NewGuid()).ToList();
                List<WordSet> Wordset = new List<WordSet>();
                if (currentGame.WordSet_Id != null || currentGame.WordSet_Id != 0)
                {
                    Wordset = DBContext.WordSets.Where(e =>e.Id == Id).Include(e=>e.Word).OrderBy(r => Guid.NewGuid()).ToList();
                }
                
                List<Contract> GameContracts = new List<Contract>();
                int playerscount = 0;
                foreach (var item in players)
                {
                    playerscount += 1;
                    Contract tempContract = new Contract()
                    {
                        Game_Id = item.Game_Id,
                        Eliminator_Id = item.User_Id,

                    };
                    if (currentGame.WordSet_Id != null)
                    {
                        //tempContract.Word_Id = Wordset.OrderBy(r => Guid.NewGuid()).First().Id;
                    }
                    if (players.Count() == playerscount)
                    {
                        tempContract.Eliminate_Id = players.First().User_Id;
                    }
                    else
                    {
                        tempContract.Eliminate_Id = players[playerscount].User_Id;
                    }
                    GameContracts.Add(tempContract);
                }

                DBContext.Contracts.AddRange(GameContracts);

                DBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
