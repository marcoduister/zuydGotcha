using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUSS.Service;
using zuydGotcha.Helper;
using Models;
using System.Data.Entity.Infrastructure;
using zuydGotcha.ViewModels.User;

namespace zuydGotcha.Controllers
{
    public class UsersController : Controller
    {
        private UserService _UserService = new UserService();

        // GET: Users
        [HttpGet]
        [CheckAuth(Roles = "Admin")]
        public ActionResult Index()
        {
            var Model = _UserService.GetAllUsers();

            return View(Model);
        }

        // GET: Users/Accept/1
        [HttpGet]
        [CheckAuth(Roles = "Admin")]
        public ActionResult Accept(int id)
        {
            return View();
        }

        // GET: Users/Details/1
        [HttpGet]
        [CheckAuth(Roles = "Admin")]
        public ActionResult Details(int id)
        {

            return View();
        }


        // GET: Users/Edit/1
        [HttpGet]
        [CheckAuth(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            EditUserViewModel ViewModel = new EditUserViewModel();

            User user = _UserService.GetUserById(id);
           
            // deze is momenteel niet in gebruik maak mapt wel viewmodel met user model
            Mapper.Model(ViewModel, user);

            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: Users/Edit/5
        [HttpPost]
        [CheckAuth(Roles = "Admin,players,GameMasters")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User Model)
        {
            if (ModelState.IsValid)
            {
                if (_UserService.EditUser(Model))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        [HttpPost]
        public void SaveProfileImage(FormCollection formCollection)
        {
            if (Request.Files.Count != 0)
            {

                byte[] Profileimage = null;
                int Id = int.Parse(formCollection["Id"]);
                using (var Reader = new BinaryReader(Request.Files[0].InputStream))
                {
                    Profileimage = Reader.ReadBytes(Request.Files[0].ContentLength);
                    
                }
                if (Profileimage != null)
                {
                    _UserService.UploadProfileImage(Profileimage,Id);
                }
            }
        }

        // GET: Users/Delete/5
        [HttpGet]
        [CheckAuth(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [CheckAuth(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
