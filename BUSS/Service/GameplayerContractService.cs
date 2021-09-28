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

        public bool JoinGameById(int id)
        {
            int UserId = int.Parse(HttpContext.Current.Session["UserID"].ToString());
            if (!DBContext.GamePlayers.Any(e => e.User_Id == UserId && e.Game_Id == id))
            {
                try
                {
                    GamePlayer player = new GamePlayer()
                    {
                        Game_Id = id,
                        User_Id = UserId,
                        Active = true
                    };

                    DBContext.GamePlayers.Add(player);
                    DBContext.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public void EliminateByGamePlayerId(int id)
        {
            GamePlayer Eliminitor = DBContext.GamePlayers
                .Include(e => e.Contract_Eliminate)
                .Where(e => e.Id == id).First();

            //GamePlayer Eliminate = DBContext.GamePlayers
            //    .Include(e => e.Contract_Eliminate)
            //    .Where(e => e.Id == Eliminitor.Contract_Eliminate.Where(a=>a.).Eliminator_Id).First();


            if (Eliminitor != null)
            {
                Contract contract = new Contract()
                {
                    Eliminator_Id = Eliminitor.User_Id,
                    Eliminate_Id = Eliminitor.Contract_Eliminate.Select(e=>e.Eliminator_Id).FirstOrDefault(),
                    Game_Id = Eliminitor.Game_Id
                    
                };
                //Eliminate.Active = false;

                //if (Eliminitor.Contract_Eliminate.Select(e=>e.Word_Id).First() != 0)
                //{
                //    contract.Word_Id = Eliminitor.Contract_Eliminate.Select(e => e.Word_Id).First();
                //}
                DBContext.Contracts.Add(contract);
            }
            

            DBContext.SaveChanges();
        }
    }
}
