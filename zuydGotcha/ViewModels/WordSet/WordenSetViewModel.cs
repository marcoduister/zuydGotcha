using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zuydGotcha.ViewModels.WordSet
{
    public class WordenSetViewModel 
    {
        public int Id { get; set; }

        public string WordSet_Name { get; set; }

        public Boolean WordSet_public { get; set; }

        public int[] SelectedIds { get; set; }

        public virtual ICollection<Word> DropdownWordList { get; set; }
    }
}