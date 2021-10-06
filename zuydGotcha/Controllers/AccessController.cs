using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BUSS.Service;
using zuydGotcha.Helper;
using Models;
using zuydGotcha.ViewModels.Access;

namespace zuydGotcha.Controllers
{
    public class AccessController : Controller
    {
        private AccessService _AccessService = new AccessService();


        // GET: Access/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (!Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        // POST: Access/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (_AccessService.validateLogin(user.Email, user.Password))
                {
                    User currentUser = _AccessService.GetUserInfo(user.Email, user.Password);
                    // Clear any lingering authencation data    
                    FormsAuthentication.SignOut();

                    // Write the authentication cookie    
                    FormsAuthentication.SetAuthCookie(currentUser.Email.ToString(), false);
                    
                    Session["UserID"] = currentUser.Id.ToString();
                    Session["UserEmail"] = currentUser.Email.ToString();
                    Session["UserName"] = currentUser.Account.FirstName + " " + currentUser.Account.LastName.ToString();
                    Session["UserRole"] = currentUser.User_Rol.ToString();


                    return RedirectToAction("Index", "Home");
                }
            }

            return View(user);
        }

        // GET: Access/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Access/Register
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel NewUser)
        {
            if (ModelState.IsValid)
            {
                if (NewUser.Password == NewUser.PasswordCheck)
                {
                    byte[] bytes = { 0, 0, 0, 25 };
                    Account AddAccount = new Account()
                    {
                        FirstName = NewUser.FirstName,
                        LastName = NewUser.LastName,
                        Alias = NewUser.Alias,
                        Group = NewUser.Groep,
                        Birthdate = DateTime.Now,
                        ProfileImage = bytes
                    };
                    User Adduser = new User()
                    {
                        Email = NewUser.Email,
                        Password = NewUser.Password,
                        User_Rol = Enums.Rolen.Player,
                        Account = AddAccount
                    };

                    if (_AccessService.Register(Adduser))
                    {
                        return RedirectToAction("Login", "Access");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(NewUser.Email), "Email is al in gebruik!!");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(NewUser.PasswordCheck), "De wachtworden komen niet over een met elkaar");
                }
            }

            return View(NewUser);
        }

        // GET: Access/PasswordReset
        [HttpGet]
        [AllowAnonymous]
        public ActionResult PasswordReset()
        {
            return View();
        }

        // POST: Access/PasswordReset
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PasswordReset(User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }

        [HttpGet]
        [CheckAuth(Roles = "Player,Gamemaster,Admin")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}