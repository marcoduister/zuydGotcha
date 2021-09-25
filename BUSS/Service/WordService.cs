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
    public class WordService
    {
        private GotchaContext DBContext = new GotchaContext();

        public IEnumerable<Word> GetAllWord()
        {
            if (DBContext.WordSets.Any())
            {
                IEnumerable<Word> wordsList = DBContext.Words.ToList();
                return wordsList;
            }
            else
            {
                List<Word> emty = new List<Word>();
                return emty;
            }
        }

        public bool CreateByModel(Word model)
        {
            try
            {
                model.Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                DBContext.Words.Add(model);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool EditByModel(Word model)
        {
            try
            {
                var Word = DBContext.Words.SingleOrDefault(e => e.Id == model.Id);
                if (Word != null)
                {
                    Word.Word_Name = model.Word_Name;
                    Word.Word_public = model.Word_public;
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

        public Word GetWordById(int id)
        {
            Word word = DBContext.Words.First(e =>e.Id == id);

            if (DBContext.Words.Any(e => e.Id == id))
            {
                Word Word = DBContext.Words.First(e => e.Id == id);
                return word;
            }
            else
            {
                return null;
            }
            
        }

        public bool DeleteByModel(Word Model)
        {
            try
            {
                if (DBContext.Words.Any(e => e.Id == Model.Id))
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

        public bool CopyByModel(Word Model)
        {
            try
            {
                if (DBContext.Words.Any(e => e.Id == Model.Id))
                {

                    Word CopyWord = new Word()
                    {
                        Word_Name = Model.Word_Name,
                        Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString())
                    };

                    DBContext.Words.Add(CopyWord);
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
