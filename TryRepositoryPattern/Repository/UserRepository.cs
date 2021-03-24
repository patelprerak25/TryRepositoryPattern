using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TryRepositoryPattern.Models;

namespace TryRepositoryPattern.Repository
{
    public class UserRepository
    {
        private DataContext dbContext = new DataContext();


        public List<User> List()
        {
            return dbContext.Users.ToList();
        }

        public void Create(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}