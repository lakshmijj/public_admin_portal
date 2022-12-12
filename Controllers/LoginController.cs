using System;
using Microsoft.AspNetCore.Mvc;
using publicAdminPortal.Models;
using Microsoft.AspNetCore.Http;

namespace publicAdminPortal.Controllers {

    public class LoginController : Controller {

        //Landing action of Login
        public IActionResult Index() {
            //For security, anytime the user hit login page, clear the session
            HttpContext.Session.Clear();  
            return View();
        }

        /*
        * Submit the login page 
        */
        public IActionResult Submit(string myUsername, string myPassword) {
            WebLogin webLogin = new WebLogin(Connection.CONNECTION_STRING, HttpContext);
            webLogin.useename = myUsername;
            webLogin.password = myPassword;
            //if the user exists, redirect to Admin
            if(webLogin.unlock()){
                return RedirectToAction("Index","Admin");
            }
            else{
                ViewData["feedback"] = "Incorrect login. Please try again...";
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult Generate(string myPassword) {
            WebLogin webLogin = new WebLogin(Connection.CONNECTION_STRING, HttpContext);
            webLogin.password = myPassword;
            string salt = webLogin.getSalt();
            string hashed = webLogin.getHashed(myPassword, salt);
            Console.WriteLine("Salt >>>>>>>>>>>>>>>"+salt);
            Console.WriteLine("Hased >>>>>>>>>>>>>>>"+hashed);
            
            return View("Index");
        }

    }
}
