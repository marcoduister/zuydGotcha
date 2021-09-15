﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuydGotcha.Models
{
    public class Word
    {

        //Atributte/property
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int Maker_Id { get; set; }

        //Relations
        public virtual User User { get; set; }
        public virtual ICollection<WordSet> WordSet { get; set; }

       
    }
}
