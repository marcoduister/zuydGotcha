using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuydGotcha.Models
{
    public class WordWordset
    {

        //Atributte/property
        public int WordSet_Id { get; set; }
        public int Word_Id { get; set; }

        //Relations
        public virtual Word Word { get; set; }
        public virtual WordSet WordSet { get; set; }

    }
}
