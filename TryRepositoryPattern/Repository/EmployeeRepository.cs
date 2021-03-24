using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TryRepositoryPattern.Models;

namespace TryRepositoryPattern.Repository
{
    public class EmployeeRepository
    {
        private DataContext dbContext = new DataContext();

        public List<Employee> List()
        {
            return dbContext.Employees.ToList();
        }

        public Employee Get(int id)
        {
            Employee emp = dbContext.Employees.Single(e => e.ID == id);

            return emp;
        }

        public void Create(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
        }

        public void Update(Employee employee)
        {
            dbContext.Entry(employee).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}