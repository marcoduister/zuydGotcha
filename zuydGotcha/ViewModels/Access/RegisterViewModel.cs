using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using zuydGotcha.Helper;
using Models;
using static Models.Enums;


namespace zuydGotcha.ViewModels.Access
{
    public class RegisterViewModel
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Alias { get; set; }

        [Required]
        public string Groep { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        public string PasswordCheck { get; set; }

        [Required]
        [CheckAge(8)]
        public DateTime Birthdate { get; set; }
    }
}