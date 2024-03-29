﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zuydGotcha.ViewModels.WordSet
{
    public class WordenSetViewModel : Models.WordSet
    {

        public int[] SelectedIds { get; set; }

        public virtual ICollection<Word> DropdownWordList { get; set; }
    }
}