﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {
        //Atributte/property
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool UserActive { get; set; }
        public Rolen User_Rol { get; set; }

        //Relations
        public virtual Account Account { get; set; }
        public virtual ICollection<Word> Word { get; set; }
        public virtual ICollection<WordSet> WordSets { get; set; }
        public virtual ICollection<Rule> Rules { get; set; }
        public virtual ICollection<RuleSet> RuleSets { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<GamePlayer> GamePlayer { get; set; }
        public virtual ICollection<GameType> GameTypes { get; set; }
        public virtual ICollection<Game> Games { get; set; }

    }
}
