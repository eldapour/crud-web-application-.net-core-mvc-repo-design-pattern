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
            return View();
        }

        [HttpPost]
        public IActionResult UserList(string search = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var userList = Iuser.GetUsers(search, jtStartIndex, jtPageSize);
                int userCount = userList.Count();
                return Json(new { Result = "OK", Records = userList , TotalRecordCount  = userCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult add(DbUser dbUser)
        {
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                    }
                    DbUser addUser = Iuser.AddUser(dbUser);
                    return Json(new { Result = "OK", Record = addUser });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
        }

        public IActionResult delete(int Id)
        {
            try
            {
                DbUser deleteUser = Iuser.DeleteUser(Id);
                return Json(new { Result = "OK" , Record = deleteUser });
            }
            catch (Exception ex)
            {

                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult edit(DbUser dbUser)
        {
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                    }
                    DbUser editUser = Iuser.EditUser(dbUser);
                    return Json(new { Result = "OK", Record = editUser });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }

        }
    }
}
