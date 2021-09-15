using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuydGotcha.Models
{
    public class RuleRuleSet
    {
        //Atributte/property
        public int Rule_Id { get; set; }
        public int RuleSet_Id { get; set; }

        //Relations
        public virtual Rule Rule { get; set; }
        public virtual RuleSet RuleSet { get; set; }
    }
}
