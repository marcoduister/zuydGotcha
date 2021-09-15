using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Models;
//using zuydGotcha.ViewModels.Access;

namespace BUSS.Service
{
    public class AccessService 
    {

        private GotchaContext DBContext = new GotchaContext();

        public  bool validateLogin(string Email, string Password )
        {
            if (DBContext.Users.Any(e =>e.Email == Email && e.Password == Password))
            {
                return true;
            }

            return false;
        }

        public  User GetUserInfo(string Email, string Password)
        {
            User ReturnUser = DBContext.Users.First(e => e.Email == Email && e.Password == Password);
            return ReturnUser;
        }

        public bool Register(User Adduser)
        {
            if (!DBContext.Users.Any(e =>e.Email == Adduser.Email))
            {
                
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