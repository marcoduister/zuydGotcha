using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuydGotcha.Models
{
    public class Contract
    {
        //Atributte/property
        [Key]
        public int Id { get; set; }
        public int Game_Id { get; set; }
        public int User_Id { get; set; }
        public int? Word_Id { get; set; }
        public DateTime? EliminatedTime { get; set; }
        public int Eliminations { get; set; }

        //Relations
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
