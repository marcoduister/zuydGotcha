using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuydGotcha.Models
{
    public class Game
    {
        //Atributte/property
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EindTime { get; set; }
        public string Location { get; set; }
        public int? RandomWiner { get; set; }
        public int? BestKill { get; set; }
        public Boolean Archived { get; set; }
        public int Maker_Id { get; set; }
        public int? WordSet_Id { get; set; }
        public int? GameType_Id { get; set; }
        public int? RuleSet_Id { get; set; }

        //Relations

        public virtual RuleSet RuleSet { get; set; }
        public virtual User User { get; set; }
        public virtual GameType GameType { get; set; }
        public virtual WordSet WordSet { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
    }
}
