using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        InventoryManagementSystemEntities db = new InventoryManagementSystemEntities();
        

        public ActionResult Dashboard()
        {
            int UserCount = db.users.Count();
            ViewBag.UserCount = UserCount;
            return View();
        }
    }
}