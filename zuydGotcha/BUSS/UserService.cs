using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zuydGotcha.DAL;
using zuydGotcha.Models;

namespace zuydGotcha.BUSS
{
    public class UserService
    {
        private GotchaContext DBContext = new GotchaContext();



        public IEnumerable<User> GetAllUsers()
        {
            if (DBContext.Users.Any())
            {
                IEnumerable<User> UserList = DBContext.Users.Where(e => e.Id != 1).ToList();
                return UserList;
            }
            else
            {
                List<User> Emty = new List<User>();
                return Emty;
            }
        }
        public User GetUserById(int Id)
        {
            if (DBContext.Users.Any(e=>e.Id == Id))
            {
                User User = DBContext.Users.First(e => e.Id == Id);

                return User;
            }
            else
            {
                return null;
            }
            
        }

        public bool EditUser(User Model)
        {
            if (!DBContext.Users.Any(e => e.Email == Model.Email))
            {
                byte[] bytes = { 0, 0, 1, 25 };


                Model.Account.ProfileImage = bytes;
                
                DBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void UploadProfileImage(byte[] profileimage)
        {
            
        }
    }
}