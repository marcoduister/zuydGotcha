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
    public class RuleSetService
    {
        private GotchaContext DBContext = new GotchaContext();

        public IEnumerable<RuleSet> GetAllRuleSets()
        {
            if (DBContext.RuleSets.Any())
            {
                IEnumerable<RuleSet> RuleSetList = DBContext.RuleSets.AsNoTracking().ToList();
                return RuleSetList;
            }
            else
            {
                List<RuleSet> emty = new List<RuleSet>();
                return emty;
            }
        }

        public bool CreateByModel(RuleSet model)
        {
            try
            {
                List<Rule> RuleenList = new List<Rule>();
                foreach (var item in model.Rule)
                {
                    RuleenList.Add(DBContext.Rules.AsNoTracking().First(e =>e.Id == item.Id));
                };
                model.Rule = RuleenList;
                model.Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString());

                DBContext.RuleSets.Add(model);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        public ICollection<Rule> GetAllMyRules()
        {

            try
            {
                int myId = int.Parse(HttpContext.Current.Session["UserID"].ToString());
                var RuleList = DBContext.Rules.AsNoTracking().Where(e => e.Maker_Id == myId).ToList();
                return RuleList;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public bool EditByModel(RuleSet model)
        {
            try
            {
                RuleSet Ruleset = DBContext.RuleSets.First(i => i.Id == model.Id);

                foreach (var item in Ruleset.Rule.ToList())
                {
                    if (!model.Rule.Any(e => e.Id == item.Id))
                        Ruleset.Rule.Remove(DBContext.Rules.First(e => e.Id == item.Id));                    
                };
                foreach (var item in model.Rule.ToList())
                {
                    if (!Ruleset.Rule.Any(e => e.Id == item.Id))
                        Ruleset.Rule.Add(DBContext.Rules.First(e => e.Id == item.Id));
                };

                Ruleset.RuleSet_Name = model.RuleSet_Name;
                Ruleset.RuleSet_public = model.RuleSet_public;

                DBContext.SaveChanges();
                return true;

            }
            catch (Exception EX)
            {

                return false;
            }

        }

        public RuleSet GetRuleSetById(int id)
        {
            RuleSet RuleSet = DBContext.RuleSets.AsNoTracking().First(e =>e.Id == id);
            
            if (DBContext.RuleSets.Any(e => e.Id == id))
            {
                RuleSet ruleSet = DBContext.RuleSets.AsNoTracking().First(e => e.Id == id);
                return ruleSet;
            }
            else
            {
                return null;
            }
            
        }

        public bool DeleteByModel(RuleSet Model)
        {
            try
            {
                if (DBContext.RuleSets.Any(e => e.Id == Model.Id))
                {
                    RuleSet DeleteRuleSet = DBContext.RuleSets.Include(e =>e.Rule).AsNoTracking().First(e => e.Id == Model.Id);

                    DBContext.Entry(DeleteRuleSet).State = EntityState.Deleted;
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

        public bool CopyByModel(int Id)
        {
            try
            {
                if (DBContext.RuleSets.AsNoTracking().Any(e => e.Id == Id))
                {
                    RuleSet RuleSet = DBContext.RuleSets.AsNoTracking().First(e => e.Id == Id);
                    RuleSet NewRuleSet = new RuleSet()
                    {
                        RuleSet_Name = RuleSet.RuleSet_Name,
                        RuleSet_public = RuleSet.RuleSet_public,
                        Maker_Id = int.Parse(HttpContext.Current.Session["UserID"].ToString()),
                    };
                    // gaat elk Rule af om tekijken als de gebruiker die al in zijn Ruleen lijst heeft en kopiert die dan
                    foreach (var item in RuleSet.Rule.ToList())
                    {
                        //maakt een kopier van Rule
                        Rule copy = new Rule()
                        {
                            Id = 0,
                            Maker_Id = NewRuleSet.Maker_Id,
                            Rule_public = item.Rule_public,
                            Rule_Name = item.Rule_Name
                        };

                        if (DBContext.Rules.Any(e=>e.Rule_Name == copy.Rule_Name && e.Maker_Id == copy.Maker_Id))
                        {
                            copy = DBContext.Rules.First(e => e.Rule_Name == copy.Rule_Name && e.Maker_Id == copy.Maker_Id);
                            copy.RuleSet = null;
                        }
                        NewRuleSet.Rule.Add(copy);
                    }
                    DBContext.RuleSets.Add(NewRuleSet);
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
    }
}
