using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static zuydGotcha.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace zuydGotcha.Models
{
    public class Account
    {
        //Atributte/property
        [Key,ForeignKey("User")]
        public int User_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public string Groep { get; set; }
        public DateTime Birthdate { get; set; }
        public byte[] ProfileImage { get; set; }

        public virtual User User { get; set; }
    }
}
