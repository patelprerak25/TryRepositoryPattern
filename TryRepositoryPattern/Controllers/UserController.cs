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
    public class UserController : Controller
    {
        private UserRepository userRepo = new UserRepository();

        // GET: User
        public ActionResult List()
        {
            return View(userRepo.List());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username, Password")] User user)
        {
            if (ModelState.IsValid)
            {
                userRepo.Create(user);
                return RedirectToAction("List");
            }

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user =  userRepo.List().ToList().Where(emp => emp.Id == id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username, Password")] User user)
        {
            if (ModelState.IsValid)
            {
                userRepo.Update(user);
                return RedirectToAction("List");
            }
            return View(user);
        }
    }
}