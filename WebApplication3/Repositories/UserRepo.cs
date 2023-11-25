using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.database;
using WebApplication3.Entities;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public class UserRepo : IUser
    {
        private readonly Context db;

        public UserRepo(Context db)
        {
            this.db = db;
        }
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DbUser> GetUsers(string search, int jtStartIndex, int jtPageSize)
        {
            IQueryable<DbUser> query = db.users;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Name.Contains(search) || a.Department.Contains(search)).OrderBy(a=>a.Name);
            }

            var data = query.Skip(jtStartIndex).Take(jtPageSize).ToList();
            return data;
        }
        /// <summary>
        ///  get user by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DbUser GetUserById(int Id)
        {
            var user = db.users.FirstOrDefault(a => a.Id == Id);
            return user;
        }
        /// <summary>
        /// get users by search
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public IEnumerable<DbUser> GetUsersBySearch(string Name)
        {
            var users = db.users.Where(a => a.Name.Contains(Name));
            return users;
        }
        /// <summary>
        /// add user
        /// </summary>
        /// <param name="dbUser"></param>
        /// <returns></returns>
        public DbUser AddUser(DbUser dbUser)
        {
            db.users.Add(dbUser);
            db.SaveChanges();
            return dbUser;
        }
        /// <summary>
        /// delete user by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DbUser DeleteUser(int Id)
        {
            var user = db.users.FirstOrDefault(a => a.Id == Id);
            if (user != null)
            {
                db.users.Remove(user);
                db.SaveChanges();
            }
            return user;
        }
        /// <summary>
        /// edit user [update data]
        /// </summary>
        /// <param name="dbUser"></param>
        /// <returns></returns>
        public DbUser EditUser(DbUser dbUser)
        {
            var oldUser = db.users.Where(a => a.Id == dbUser.Id).FirstOrDefault();
            oldUser.Name = dbUser.Name;
            oldUser.Department = dbUser.Department;
            db.SaveChanges();
            return dbUser;
        }

    }
}
