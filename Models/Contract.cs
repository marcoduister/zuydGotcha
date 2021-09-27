using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contract
    {
        //Atributte/property
        [Key]
        public int Id { get; set; }

        public int Eliminate_Id { get; set; }

        public int Eliminator_Id { get; set; }

        [ForeignKey("Word")]
        public int? Word_Id { get; set; }

        public DateTime? EliminatedTime { get; set; }

        public string Story { get; set; }

        [ForeignKey("Game")]
        public int Game_Id { get; set; }

        //Relations
        public virtual Game Game { get; set; }
        public virtual Word Word { get; set; }
        public virtual GamePlayer GamePlayer_Eliminate { get; set; }
        public virtual GamePlayer GamePlayer_Eliminator { get; set; }
    }
}
