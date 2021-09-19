using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace zuydGotcha.ViewModels.Gametypes
{
    public class AddGametypeViewModel
    {
        [Required]
        public string GameType_Name { get; set; }

        [Required]
        public string GameType_Description { get; set; }
    }
}