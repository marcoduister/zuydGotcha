using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace BUSS.Service
{
    public class GametypeService
    {
        private GotchaContext DBContext = new GotchaContext();

        public IEnumerable<GameType> GetAllGametypes()
        {
            if (DBContext.Users.Any())
            {
                IEnumerable<GameType> gametypeList = DBContext.GameTypes.Where(e => e.Id != 1).ToList();
                return gametypeList;
            }
            else
            {
                List<GameType> emty = new List<GameType>();
                return emty;
            }
        }


    }
}
