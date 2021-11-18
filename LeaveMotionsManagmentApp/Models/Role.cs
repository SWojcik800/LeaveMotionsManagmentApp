using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Models
{
    public class Role : IdentityRole
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
