using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zuydGotcha.DAL;
using zuydGotcha.Models;
using zuydGotcha.ViewModels.Access;

namespace zuydGotcha.BUSS
{
    public class AccessService
    {

        private GotchaContext DBContext = new GotchaContext();

        internal bool validateLogin(string Email, string Password )
        {
            if (DBContext.Users.Any(e =>e.Email == Email && e.Password == Password))
            {
                return true;
            }

            return false;
        }

        internal User GetUserInfo(string Email, string Password)
        {
            User ReturnUser = DBContext.Users.First(e => e.Email == Email && e.Password == Password);
            return ReturnUser;
        }

        internal bool Register(RegisterViewModel NewUser)
        {
            if (!DBContext.Users.Any(e =>e.Email == NewUser.Email))
            {
                byte[] bytes = { 0, 0, 0, 25 };

                Account AddAccount = new Account()
                {
                    FirstName = NewUser.FirstName,
                    LastName = NewUser.LastName,
                    Alias = NewUser.Alias,
                    Groep = NewUser.Groep,
                    Birthdate = DateTime.Now,
                    ProfileImage = bytes

                };
                User Adduser = new User()
                {
                    Email = NewUser.Email,
                    Password = NewUser.Password,
                    Rol = Enums.Rolen.Player,
                    Account = AddAccount
                };


                

                DBContext.Users.Add(Adduser);
                DBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}