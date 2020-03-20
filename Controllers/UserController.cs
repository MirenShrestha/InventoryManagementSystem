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
                                 Username = u.Username,
                                 Email = u.Email,
                                 
                                 ContactNo = u.ContactNo,
                                 Address = u.Address,
                                 Status = u.StatusId,
                                 Role = u.tblRole.Role



                             }).ToList();
            return View(lstvmUser);
        }



        public ActionResult AddNewUser ()
        {
            UserViewModel vm = new UserViewModel();
           
            vm.UserRoleList = db.tblRoles.Select(c => new SelectListItem { Text = c.Role, Value = c.Id.ToString() }).ToList();
           
            return View(vm);
        }


        [HttpPost]
        public ActionResult AddNewUser(UserViewModel vmodel)
        {

            vmodel.UserRoleList = db.tblRoles.Select(c => new SelectListItem { Text = c.Role, Value = c.Id.ToString() }).ToList();
            //if (ModelState.IsValid)
            //{
                tblUser user = new tblUser();
                user.StatusId = 1;                

                user.Username = vmodel.Username;
                user.Password = vmodel.Password;
                user.Firstname = vmodel.Firstname;
                user.Lastname = vmodel.Lastname;
                user.ContactNo = vmodel.ContactNo;
                user.Address = vmodel.Address;
                user.Email = vmodel.Email;                
                user.RoleId = vmodel.RoleId;          
                
                db.tblUsers.Add(user);        

                db.SaveChanges();

                return RedirectToAction("User");        
        }




        public ActionResult Edit(int id)
        {
             UserViewModel vm  = new UserViewModel();
            vm.UserRoleList = db.tblRoles.Select(c => new SelectListItem { Text = c.Role, Value = c.Id.ToString() }).ToList();
            if (id > 0)
            {
                var user = db.tblUsers.Where(c => c.Id == id).FirstOrDefault();
                vm.Id = user.Id;
                vm.Firstname = user.Firstname;
                vm.Lastname = user.Lastname;
                vm.Username = user.Username;
                vm.Email = user.Email;               
                vm.ContactNo = user.ContactNo;
                vm.Address = user.Address;
                vm.Status = user.StatusId;
                vm.RoleId = user.RoleId;
            }
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel vmuser)
        {

            vmuser.UserRoleList = db.tblRoles.Select(c => new SelectListItem { Text = c.Role, Value = c.Id.ToString() }).ToList();
            //if (ModelState.IsValid) 
            //{
               tblUser user = new tblUser();
                user.StatusId = 1;
                if (vmuser.Id > 0)
                {
                    user = db.tblUsers.Where(c => c.Id == vmuser.Id).FirstOrDefault();
                }
              
             
                user.Firstname = vmuser.Firstname;
                user.Lastname = vmuser.Lastname;
            user.Username = vmuser.Username;
            user.Password = vmuser.Password;
            user.ContactNo = vmuser.ContactNo;
                user.Address = vmuser.Address;
                user.Email = vmuser.Email;
                user.RoleId = vmuser.RoleId;

                db.SaveChanges();

                return RedirectToAction("User");

            //}

            return View(vmuser);

        }


        public ActionResult Delete(int id)
        {
            UserViewModel vm = new UserViewModel();

            vm.UserRoleList = db.tblRoles.Select(c => new SelectListItem { Text = c.Role, Value = c.Id.ToString() }).ToList();

            var user = db.tblUsers.Where(c => c.Id == id).FirstOrDefault();
            vm.Id = user.Id;
            vm.Firstname = user.Firstname;
            vm.Lastname = user.Lastname;
            vm.Username = user.Username;
            vm.Email = user.Email;
            vm.ContactNo = user.ContactNo;
            vm.Address = user.Address;
            vm.Status = user.StatusId;
            vm.RoleId = user.RoleId;

            return View(vm);

        }


        [HttpPost]
        public ActionResult Delete(UserViewModel uvm)
        {

            UserViewModel uv = new UserViewModel();
            //uv.UserRoleList = db.tblRoles.Select(c => new SelectListItem { Text = c.Role, Value = c.Id.ToString() }).ToList();

            var user = db.tblUsers.Where(c => c.Id == uvm.Id).FirstOrDefault();            
            
            tblUser tb = db.tblUsers.Find(uvm.Id);
            db.tblUsers.Remove(tb);
            db.SaveChanges();
            return RedirectToAction("User");
        }





    }
}