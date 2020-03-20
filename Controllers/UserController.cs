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
        public ActionResult Edit(int id)
        {
            var dbUser = db.tblUsers.Include(m => m.tblRole).SingleOrDefault(c=>c.Id==id);
            UserViewModel userView=new UserViewModel();
            userView.Id = dbUser.Id;
            userView.Firstname = dbUser.Firstname;
            userView.Lastname = dbUser.Lastname;
            userView.Email = dbUser.Email;
            userView.ContactNo = dbUser.ContactNo;
            userView.Address = dbUser.Address;
            userView.Status = dbUser.StatusId;
            userView.Role = dbUser.tblRole.Role;
            return View(userView);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userView)
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}