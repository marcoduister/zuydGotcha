using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GamePlayer
    {
        //Atributte/property
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }

        public Boolean Active { get; set; }

        [ForeignKey("Game")]
        public int Game_Id { get; set; }

        //Relations
        public virtual User User { get; set; }
        public virtual Game Game { get; set; }

        public virtual ICollection<Contract> Contract_Eliminate { get; set; }

        public virtual ICollection<Contract> Contract_Eliminators { get; set; }




    }
}
