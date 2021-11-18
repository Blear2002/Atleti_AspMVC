using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atleti_AspMVC.Models;
using Atleti_AspMVC.ViewModels;

namespace Atleti_AspMVC.Controllers
{
    public class SportsController : Controller
    {
        // GET: Sports

        public ActionResult Index()
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                List<Sport> sports = model.Sports.OrderBy(o => o.Name).ToList();
                if (sports.Count() == 0)
                {
                    //httpNotFoundResult
                    return HttpNotFound();
                }
                else
                {
                    //viewResult
                    return View(sports);
                }
            }
        }

        public ActionResult Details(int id)
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                Sport sport = model.Sports.FirstOrDefault(q => q.Id == id);

                if (sport == null)
                {
                    //httpNotFoundResult
                    return HttpNotFound();
                }
                else
                {
                    //viewResult
                    return View(sport);
                }
            }
        }

        public ActionResult Edit(int id) //get
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                Sport sport = model.Sports.FirstOrDefault(q => q.Id == id);
                if (sport == null)
                {
                    //httpNotFoundResult
                    return HttpNotFound();
                }
                else
                {
                    //viewResult
                    return View(sport);
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(Sport s) //post
        {
            if (s == null) return HttpNotFound();

            using (OlympicsEntities model = new OlympicsEntities())
            {
                Sport candidate = model.Sports.FirstOrDefault(q => q.Id == s.Id);
                if (candidate == null) return HttpNotFound();

                candidate.Name = s.Name;                
                model.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sport s)
        {
            if (s == null) return HttpNotFound();

            using (OlympicsEntities model = new OlympicsEntities())
            {
                model.Sports.Add(s);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
 }