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
        private DataContext dbContext;

        public UserRepository(DataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<User> List()
        {
            return dbContext.Users.ToList();
        }

        public void Create(User user)
        {
            dbContext.Users.Add(user);
        }

        public void Update(User user)
        {
            dbContext.Entry(user).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}