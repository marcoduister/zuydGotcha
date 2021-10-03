using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zuydGotcha.ViewModels.RuleSet
{
    public class RuleSetViewModel
    {
        public int Id { get; set; }

        public string RuleSet_Name { get; set; }

        public Boolean RuleSet_public { get; set; }

        public int[] SelectedIds { get; set; }

        public virtual ICollection<Rule> DropdownRuleList { get; set; }
    }
}