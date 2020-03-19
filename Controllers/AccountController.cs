using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class AccountController : Controller
    {

        InventoryManagementSystemEntities db = new InventoryManagementSystemEntities();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SignIn()
        {           
            return View();
        }


        [HttpPost]
        public ActionResult SignIn(AccountViewModel vmuser)
        {
            var user = db.tblUsers.Where(c => c.Username == vmuser.Username && c.Password == vmuser.Password).FirstOrDefault();
            if (user != null)
            {
                Session["Fullname"] = user.Firstname + " " + user.Lastname;
                return RedirectToAction("DashBoard", "Dashboard");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Credentials Supplied");
                return View("SignIn");
            }
            return View();
        }
       


    }
}