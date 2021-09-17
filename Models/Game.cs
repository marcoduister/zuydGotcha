using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        //Atributte/property
        [Key]
        public int Id { get; set; }
        public string Game_Name { get; set; }

        public DateTime? Game_Start { get; set; }

        public DateTime? Game_Eind { get; set; }

        public string Location { get; set; }

        public Boolean Archived { get; set; }
        public int? RandomWiner { get; set; }
        public int? BestKill { get; set; }

        [ForeignKey("User")]
        public int Maker_Id { get; set; }

        [ForeignKey("WordSet")]
        public int? WordSet_Id { get; set; }

        [ForeignKey("GameType")]
        public int? GameType_Id { get; set; }

        [ForeignKey("RuleSet")]
        public int? RuleSet_Id { get; set; }

        //Relations

        public virtual RuleSet RuleSet { get; set; }
        public virtual User User { get; set; }
        public virtual GameType GameType { get; set; }
        public virtual WordSet WordSet { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }

    }
}
