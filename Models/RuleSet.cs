using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RuleSet
    {
        public RuleSet()
        {
            this.Rule = new HashSet<Rule>();
        }

        //Atributte/property
        [Key]
        public int Id { get; set; }
        public int Maker_Id { get; set; }
        public string Name { get; set; }

        //Relations
        public virtual ICollection<Rule> Rule { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual User User { get; set; }
    }
}
