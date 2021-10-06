using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zuydGotcha.ViewModels.RuleSet
{
    public class RuleSetViewModel : Models.RuleSet
    {

        public int[] SelectedIds { get; set; }

        public virtual ICollection<Rule> DropdownRuleList { get; set; }
    }
}