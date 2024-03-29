﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Models;

namespace BUSS.Service
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
                
                DBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UploadProfileImage(byte[] _profileimage,int Id)
        {
            if (DBContext.Account.Any(e => e.User_Id == Id))
            {
                Account updateprofile = DBContext.Account.First(e => e.User_Id == Id);

                updateprofile.ProfileImage = _profileimage;

                DBContext.SaveChanges();
            }
        }
    }
}