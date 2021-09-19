using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zuydGotcha.ViewModels.Game
{
    public class GameViewmodel
    {
        public int Id { get; set; }

        public string Game_Name { get; set; }

        public DateTime? Game_Start { get; set; }

        public DateTime? Game_Eind { get; set; }

        public string Location { get; set; }

        public Boolean Archived { get; set; }

        public Boolean Game_public { get; set; }
        public Boolean Creator { get; set; }
    }
}