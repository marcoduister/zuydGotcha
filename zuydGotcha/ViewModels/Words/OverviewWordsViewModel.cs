using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zuydGotcha.ViewModels.Words
{
    public class OverviewWordsViewModel
    {
        public int Id { get; set; }

        public string Word_Name { get; set; }

        public Boolean Word_public { get; set; }

        public int Maker_Id { get; set; }
    }
}