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
    public class RuleService
    {
        private GotchaContext DBContext = new GotchaContext();

        public IEnumerable<Rule> GetAllRule()
        {
            if (DBContext.Rules.Any())
            {
                IEnumerable<Rule> RulesList = DBContext.Rules.ToList();
                return RulesList;
            }
            else
            {
                List<Rule> emty = new List<Rule>();
                return emty;
            }
        }

        public bool CreateByModel(Rule model)
        {
            try
            {
                model.Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                DBContext.Rules.Add(model);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool EditByModel(Rule model)
        {
            try
            {
                var Rule = DBContext.Rules.SingleOrDefault(e => e.Id == model.Id);
                if (Rule != null)
                {
                    Rule.Rule_Name = model.Rule_Name;
                    Rule.Rule_Description = model.Rule_Description;
                    Rule.Rule_public = model.Rule_public;
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

        public Rule GetRuleById(int id)
        {
            Rule Rule = DBContext.Rules.First(e =>e.Id == id);

            if (DBContext.Rules.Any(e => e.Id == id))
            {
                Rule rule = DBContext.Rules.First(e => e.Id == id);
                return rule;
            }
            else
            {
                return null;
            }
            
        }

        public bool DeleteByModel(Rule Model)
        {
            try
            {
                if (DBContext.Rules.Any(e => e.Id == Model.Id))
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

        public bool CopyByModel(Rule Model)
        {
            try
            {
                if (DBContext.Rules.Any(e => e.Id == Model.Id))
                {

                    Rule CopyRule = new Rule()
                    {
                        Rule_Name = Model.Rule_Name,
                        Rule_Description = Model.Rule_Description,
                        Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString())
                    };

                    DBContext.Rules.Add(CopyRule);
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
