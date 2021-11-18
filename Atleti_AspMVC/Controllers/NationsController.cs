
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Atleti_AspMVC.Models;
using Atleti_AspMVC.ViewModels;

namespace Atleti_AspMVC.Controllers
{
    public class NationsController : Controller
    {        
        // GET: Nations
        public ActionResult Random() //ActionResult classe base dove vado a restituire una vista con vari risultati
        {
            //interrogazione del model
            using (OlympicsEntities model = new OlympicsEntities())
            {
                System.Random randomGenerator = new Random();

                int randomValue = randomGenerator.Next(model.Nationalities.Count() - 1);

                Nationality nation = model.Nationalities.OrderBy(o => o.Id).Skip(randomValue).FirstOrDefault();

                if (nation == null)
                {
                    //httpNotFoundResult
                    return HttpNotFound();
                }
                else
                {
                    //viewResult
                    return View("Details", new NationsDetailViewModel
                    {
                        Title = "Random",
                        Nation = nation
                    });
                }

                //rienderizzo l'utente ad un altro percorso/link
                //RedirectToAction();

                //ContentResult
                //return Content(nation.Code); -> mi restituisce solo del testo invece che l'intero html

                //ritorna il nulla
                //return new EmptyResult();

            }
        }

        public ActionResult Details(int id)
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                Nationality nation = model.Nationalities.FirstOrDefault(q => q.Id == id);

                if (nation == null)
                {
                    //httpNotFoundResult
                    return HttpNotFound();
                }
                else
                {
                    //viewResult
                    return View(new NationsDetailViewModel
                    {   Title = "Details",
                        Nation = nation
                    });
                }
            }
        }

        [Route("Nations/GetByCode/{code}")] //invece che scriverlo nel rout config lo scrivo qua -- attribute routing
        public ActionResult GetByCode(string code)
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                Nationality nation = model.Nationalities.FirstOrDefault(q => q.Code == code);

                if (nation == null)
                {
                    //httpNotFoundResult
                    return HttpNotFound();
                }
                else
                {
                    //viewResult
                    return View("Details", new NationsDetailViewModel
                    {   Title = "ByCode",
                        Nation = nation
                    });
                }
            }
        }


        public ActionResult Index(int id = 1)
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                const int pageSize = 10;

                List<Nationality> nazionalità = model.Nationalities.OrderBy(o => o.Code)
                                   .Skip((id - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();

                if (nazionalità.Count() == 0)
                {
                    //httpNotFoundResult
                    return HttpNotFound();
                }
                else
                {
                    
                    int pages = model.Nationalities.Count() / pageSize;
                    if (model.Nationalities.Count() % pageSize != 0) pages++;

                    //viewResult
                    return View(new NationsListViewModel
                    {
                        Page = id, //pagina attuale 
                        Pages = pages, //pagine disponibili
                        Nations = nazionalità //lista di nazionali
                    });
                }
            }
        }

        public ActionResult Edit(int id) //get -- specifico quella nazione che voglio modificare
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                Nationality nation = model.Nationalities.FirstOrDefault(q => q.Id == id);
                if (nation==null)
                {
                    //httpNotFoundResult
                    return HttpNotFound();
                }
                else
                {
                    //viewResult
                    return View(nation);
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(Nationality n) //post -- vado ad editare la nazione e salvo le modifiche 
        {
            if (n == null) return HttpNotFound();

            using(OlympicsEntities model = new OlympicsEntities())
            {
                Nationality candidate = model.Nationalities.FirstOrDefault(q => q.Id == n.Id);
                if (candidate == null) return HttpNotFound();

                candidate.Code = n.Code;
                candidate.Name = n.Name;
                model.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Create() //get
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Nationality n) //post
        {
            if (n == null) return HttpNotFound();

            using(OlympicsEntities model = new OlympicsEntities())
            {
                model.Nationalities.Add(n);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}