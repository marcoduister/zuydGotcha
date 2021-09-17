using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Word
    {
        public Word()
        {
            this.WordSets = new HashSet<WordSet>();
        }

        //Atributte/property
        [Key]
        public int Id { get; set; }

        public string Word_Name { get; set; }

        public Boolean Word_public { get; set; }

        [ForeignKey("User")]
        public int Maker_Id { get; set; }

        //Relations
        public virtual User User { get; set; }
        public virtual ICollection<WordSet> WordSets { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }


    }
}
