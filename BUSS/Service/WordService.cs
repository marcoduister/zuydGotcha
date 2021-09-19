using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace BUSS.Service
{
    public class WordService
    {
        private GotchaContext DBContext = new GotchaContext();

        public IEnumerable<WordSet> GetAllWordsets()
        {
            if (DBContext.WordSets.Any())
            {
                IEnumerable<WordSet> wordsetList = DBContext.WordSets.Where(e => e.Id != 1).ToList();
                return wordsetList;
            }
            else
            {
                List<WordSet> emty = new List<WordSet>();
                return emty;
            }
        }
    }
}
