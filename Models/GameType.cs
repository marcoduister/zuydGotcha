using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GameType
    {
        //Atributte/property
        [Key]
        public int Id { get; set; }

        public string GameType_Name { get; set; }

        public string GameType_Description { get; set; }

        [ForeignKey("User")]
        public int Maker_Id { get; set; }

        //Relations
        public virtual ICollection<Game> Games { get; set; }
        public virtual User User { get; set; }
    }
}
