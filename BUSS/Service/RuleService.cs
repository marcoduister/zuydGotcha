using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace BUSS.Service
{
    public class RuleService
    {
        private GotchaContext DBContext = new GotchaContext();

        public IEnumerable<RuleSet> GetAllRulesets()
        {
            if (DBContext.RuleSets.Any())
            {
                IEnumerable<RuleSet> rulesetList = DBContext.RuleSets.Where(e => e.Id != 1).ToList();
                return rulesetList;
            }
            else
            {
                List<RuleSet> emty = new List<RuleSet>();
                return emty;
            }
        }
    }
}
