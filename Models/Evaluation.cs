using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Evaluation
    {
        //Atributte/property
        [Key]
        public int Id { get; set; }

        public int Points { get; set; }

        public string Game_Review { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }

        [ForeignKey("Game")]
        public int Game_Id { get; set; }

        //Relations
        public virtual User User { get; set; }
        public virtual Game Game { get; set; }
    }
}
