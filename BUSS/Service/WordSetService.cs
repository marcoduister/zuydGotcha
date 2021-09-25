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
    public class WordSetService
    {
        private GotchaContext DBContext = new GotchaContext();

        public IEnumerable<WordSet> GetAllWordSets()
        {
            if (DBContext.WordSets.Any())
            {
                IEnumerable<WordSet> wordSetList = DBContext.WordSets.AsNoTracking().ToList();
                return wordSetList;
            }
            else
            {
                List<WordSet> emty = new List<WordSet>();
                return emty;
            }
        }

        public bool CreateByModel(WordSet model)
        {
            try
            {
                List<Word> WordenList = new List<Word>();
                foreach (var item in model.Word)
                {
                    WordenList.Add(DBContext.Words.AsNoTracking().First(e =>e.Id == item.Id));
                };
                model.Word = WordenList;
                model.Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString());

                DBContext.WordSets.Add(model);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        public ICollection<Word> GetAllMyWords()
        {

            try
            {
                int myId = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                var WordList = DBContext.Words.AsNoTracking().Where(e => e.Maker_Id == myId).ToList();
                return WordList;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public bool EditByModel(WordSet model)
        {
            try
            {
                WordSet Wordset = DBContext.WordSets.First(i => i.Id == model.Id);

                foreach (var item in Wordset.Word.ToList())
                {
                    if (!model.Word.Any(e => e.Id == item.Id))
                        Wordset.Word.Remove(DBContext.Words.First(e => e.Id == item.Id));                    
                };
                foreach (var item in model.Word.ToList())
                {
                    if (!Wordset.Word.Any(e => e.Id == item.Id))
                        Wordset.Word.Add(DBContext.Words.First(e => e.Id == item.Id));
                };

                model.Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString());

                DBContext.SaveChanges();
                return true;

            }
            catch (Exception EX)
            {

                return false;
            }

        }

        public WordSet GetWordSetById(int id)
        {
            WordSet wordSet = DBContext.WordSets.AsNoTracking().First(e =>e.Id == id);

            if (DBContext.WordSets.Any(e => e.Id == id))
            {
                WordSet WordSet = DBContext.WordSets.AsNoTracking().First(e => e.Id == id);
                return wordSet;
            }
            else
            {
                return null;
            }
            
        }

        public bool DeleteByModel(WordSet Model)
        {
            try
            {
                if (DBContext.WordSets.Any(e => e.Id == Model.Id))
                {
                    WordSet DeleteWordSet = DBContext.WordSets.Include(e =>e.Word).AsNoTracking().First(e => e.Id == Model.Id);


                    DBContext.WordSets.Remove(DeleteWordSet);
                    //DBContext.Entry(DeleteWordSet).State = EntityState.Deleted;
                    DBContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool CopyByModel(WordSet Model)
        {
            try
            {
                if (DBContext.WordSets.Any(e => e.Id == Model.Id))
                {

                    WordSet CopyWordSet = new WordSet()
                    {
                        WordSet_Name = Model.WordSet_Name,
                        Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString())
                    };

                    DBContext.WordSets.Add(CopyWordSet);
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
