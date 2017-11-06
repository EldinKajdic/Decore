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
    public class StudentController : Controller
    {
        StudentServiceClient studentService = new StudentServiceClient();
        UserServiceClient userService = new UserServiceClient();

        // GET: Student
        public ActionResult Index()
        {
            List<StudentInfo> studentList = studentService.GetAllStudents().ToList();
            return View(studentList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            StudentInfo studentInfo = studentService.GetStudentByUserId(id);
            return View(studentInfo);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            StudentInfo createStudent = new StudentInfo();
            return View(createStudent);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentInfo newStudent)
        {
            try
            {
                studentService.CreateStudent(newStudent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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

        public ActionResult LogOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
