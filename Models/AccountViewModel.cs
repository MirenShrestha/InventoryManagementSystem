using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public long ContactNo { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public int RoleId { get; set; }

       
        public string Username { get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string LoginErrorMessage { get; set; }

    }
}