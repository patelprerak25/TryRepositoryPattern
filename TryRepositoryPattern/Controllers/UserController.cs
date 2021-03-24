using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TryRepositoryPattern.Models;

namespace TryRepositoryPattern.Controllers
{
    public class UserController : Controller
    {
        private DataContext dbContext = new DataContext();

        // GET: User
        public ActionResult List()
        {
            return View(dbContext.Users.ToList());
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
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return RedirectToAction("List");
            }

            return View(user);
        }
    }
}