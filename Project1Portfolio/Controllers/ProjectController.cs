using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class ProjectController : Controller
    {

        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult ProjectList()
        {
            var values = context.Proje.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Proje proje)
        {
            context.Proje.Add(proje);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = context.Proje.Find(id);
            context.Proje.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = context.Proje.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(Proje proje)
        {
            var value = context.Proje.Find(proje.ProjectId);
            value.Title = proje.Title;
            value.Description = proje.Description;
            
            context.SaveChanges();
            return RedirectToAction("ProjectList");

        }
    }
}