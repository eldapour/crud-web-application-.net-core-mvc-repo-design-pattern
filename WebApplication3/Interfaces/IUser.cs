using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IUser
    {
        IEnumerable<DbUser> GetUsers(string search, int jtStartIndex, int jtPageSize);
        IEnumerable<DbUser> GetUsersBySearch(string Name);
        DbUser GetUserById(int Id);
        DbUser AddUser(DbUser dbUser);
        DbUser EditUser(DbUser dbUser);
        DbUser DeleteUser(int Id);
    }
}
