using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TryRepositoryPattern.Models;

namespace TryRepositoryPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private DataContext dbContext = new DataContext();

        // GET: Employee
        public ActionResult List()
        {
            return View(dbContext.Employees.ToList());
        }

        public ActionResult Detail(int id)
        {
            Employee employee = dbContext.Employees.Single(emp => emp.ID == id);

            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return RedirectToAction("List");
            }

            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Gender,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(employee).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return View(employee);
        }

    }
}