using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Name { get; set; }
        public int Maker_Id { get; set; }

        //Relations
        public virtual ICollection<Word> Word { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual User User { get; set; }
    }
}
