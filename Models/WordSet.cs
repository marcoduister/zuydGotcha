using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class WordSet
    {
        public WordSet()
        {
            this.Word = new HashSet<Word>();
        }

        //Atributte/propertie
        [Key]
        public int Id { get; set; }

        public string WordSet_Name { get; set; }

        public Boolean WordSet_public { get; set; }

        [ForeignKey("User")]
        public int Maker_Id { get; set; }

        //Relations
        public virtual ICollection<Word> Word { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual User User { get; set; }
    }
}
