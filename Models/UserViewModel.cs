using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public long ContactNo { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }

        public int RoleId { get; set; }
        public string Role { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public List<System.Web.Mvc.SelectListItem> UserRoleList { get; set; }



    }
}