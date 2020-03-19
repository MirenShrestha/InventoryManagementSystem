using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        InventoryManagementSystemEntities db = new InventoryManagementSystemEntities();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult User()
        {
            var lstdbUser = db.tblUsers.Include( m => m.tblRole).ToList();
            var lstvmUser = (from u in lstdbUser
                             select new UserViewModel
                             {
                                 Id = u.Id,
                                 Firstname = u.Firstname,
                                 Lastname = u.Lastname,
                                 Email = u.Email,
                                 
                                 ContactNo = u.ContactNo,
                                 Address = u.Address,
                                 Status = u.StatusId,
                                 Role = u.tblRole.Role



                             }).ToList();
            return View(lstvmUser);
        }
    }
}