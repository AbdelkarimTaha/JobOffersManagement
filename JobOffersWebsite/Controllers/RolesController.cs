using JobOffersWebsite.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOffersWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        public ActionResult Details(string id)
        {
            var role = db.Roles.Find(id);

            if (role == null)
                return HttpNotFound();

            return View(role);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(string id)
        {
            var role = db.Roles.Find(id);

            if (role == null)
                return HttpNotFound();

            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        public ActionResult Delete(string id)
        {
            var role = db.Roles.Find(id);

            if (role == null)
                return HttpNotFound();

            return View(role);
        }

        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var roleInDb = db.Roles.Find(role.Id);
                db.Roles.Remove(roleInDb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
