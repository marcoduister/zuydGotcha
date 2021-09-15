using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rule
    {
        public Rule()
        {
            this.RuleSet = new HashSet<RuleSet>();
        }

        //Atributte/property
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Maker_Id { get; set; }

        //Relations
        public virtual User User { get; set; }
        public virtual ICollection<RuleSet> RuleSet { get; set; }

    }
}
