using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TryRepositoryPattern.Models;
using TryRepositoryPattern.Repository;

namespace TryRepositoryPattern.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository empRepo = new EmployeeRepository();
        // GET: Employee
        public ActionResult List()
        {
            return View(empRepo.List());
        }

        public ActionResult Detail(int id)
        {
            Employee employee = empRepo.Get(id);

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
                empRepo.Create(employee);
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
            Employee employee = empRepo.List().ToList().Where(emp => emp.ID == id).FirstOrDefault();
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
                empRepo.Update(employee);
                return RedirectToAction("List");
            }
            return View(employee);
        }

        
    }
}