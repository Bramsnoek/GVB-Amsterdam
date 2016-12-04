using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EyeCT4RailsBackend;

namespace EyeCT4RailsASP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User account)
        {	
			ValidateUser validateUser = (ValidateUser)Session["ValidateUser"];

            if (validateUser.Login(account))
            {
                ((Remise)Session["Remise"]).SetLoggedInUser(account.Username.ToString());
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Username or Password is wrong.");
            return View();

        }

		[HttpGet]
		public ActionResult Logout()
		{
			((Remise)Session["Remise"]).UserLoggedIn = null;
			return RedirectToAction("Login", "Login");
		}
	}
}