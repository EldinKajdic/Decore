using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DecoreLogin.LoginServiceReference;

namespace DecoreLogin.Controllers
{
    public class HomeController : Controller
    {
        LoginServiceClient loginService = new LoginServiceClient();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(string userinputLogin, string passwordinputLogin)
        {
            EmployeeUsers employeeUser = new EmployeeUsers();

          
                employeeUser = loginService.LoginEmployee(userinputLogin, passwordinputLogin);

                if (employeeUser.SuccessfulOperation == true)
                {
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(employeeUser.Id.ToString(), false);
                }

            return View("Index");
        }
    }
}