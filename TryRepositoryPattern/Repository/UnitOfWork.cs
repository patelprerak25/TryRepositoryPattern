using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TryRepositoryPattern.Models;

namespace TryRepositoryPattern.Repository
{
    public class UnitOfWork
    {
        private DataContext dbContext;
        private EmployeeRepository empRepo;
        private UserRepository userRepo;

        public UnitOfWork(DataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public EmployeeRepository EmployeeRepo
        {
            get
            {
                if (empRepo == null)
                    return new EmployeeRepository(dbContext);
                return empRepo;
            }
        }

        public UserRepository UserRepo
        {
            get
            {
                if (userRepo == null)
                    userRepo = new UserRepository(dbContext);
                return userRepo;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}