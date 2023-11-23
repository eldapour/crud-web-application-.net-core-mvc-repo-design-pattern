using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser Iuser;
        
        public UserController(IUser Iuser)
        {
            this.Iuser = Iuser;
        } // 
        public IActionResult Index()
        {
            var users = Iuser.GetUsers();
            return View(users);
        }
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add(DbUser dbUser)
        {
            if (ModelState.IsValid)
            {
                Iuser.AddUser(dbUser);
                return Redirect("/user/");
            }
            else
            {
                return View();
            }
        }

        public IActionResult delete(int Id)
        {
            Iuser.DeleteUser(Id);
            return Redirect("/user/");
        }
        
        public IActionResult edit(int Id)
        {
            var data = Iuser.GetUserById(Id);
            return View(data);

        }
    }
}
