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
        private UnitOfWork unitOfWork = new UnitOfWork(new DataContext());
        // GET: Employee
        public ActionResult List()
        {
            return View(unitOfWork.EmployeeRepo.List());
        }

        public ActionResult Detail(int id)
        {
            Employee employee = unitOfWork.EmployeeRepo.Get(id);

            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Used Unit of work feature for multiple repository query using single save command.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EmployeeRepo.Create(employee);

                User user = new User { Username = employee.FirstName, Password = employee.LastName };
                unitOfWork.UserRepo.Create(user);

                unitOfWork.Save();
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
            Employee employee = unitOfWork.EmployeeRepo.List().ToList().Where(emp => emp.ID == id).FirstOrDefault();
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
                unitOfWork.EmployeeRepo.Update(employee);
                unitOfWork.Save();
                return RedirectToAction("List");
            }
            return View(employee);
        }

        
    }
}