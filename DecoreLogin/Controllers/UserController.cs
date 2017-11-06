using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DecoreLogin.StudentServiceReference;
using DecoreLogin.UserServiceReference;
using DecoreLogin.LoginServiceReference;

namespace DecoreLogin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        
        UserServiceClient userService = new UserServiceClient();
        
        // GET: User
        public ActionResult Index()
        {
            List<UserInfo> userInfoList = userService.GetAllUsers().ToList();

            return View(userInfoList);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            UserInfo userInfo = new UserInfo();
            return View(userInfo);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserInfo newUser)
        {
            try
            {
                userService.CreateUser(newUser);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
