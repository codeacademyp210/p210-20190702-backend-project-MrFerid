using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEndProject.Controllers
{
    [Authorize]
    public class SheduleController : Controller
    {
        // GET: Shedule
        ClubDB db = new ClubDB();
        public ActionResult Index()
        {
            SheduleVM model = new SheduleVM()
            {
                shedule = new Schedule(),
                courses = db.Course.ToList(),
                rooms = db.Room.ToList(),
                trainers = db.Trainers.ToList(),
                shedules = db.Schedule.ToList(),
                Header = "Add Schedule",
                Action = "Create"
            };
            return View(model);
        }

        // POST: Shedule/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Description")]Schedule shedule, string content)
        {
            if (shedule != null)
            {
                shedule.Description = content;
                db.Schedule.Add(shedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Shedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Schedule she = db.Schedule.FirstOrDefault(p => p.id == id);
                if (she != null)
                {
                    SheduleVM model = new SheduleVM()
                    {
                        shedule = she,
                        courses = db.Course.ToList(),
                        rooms = db.Room.ToList(),
                        trainers = db.Trainers.ToList(),
                        shedules = db.Schedule.ToList(),
                        Header = "Edit Schedule",
                        Action = "Edit"
                    };
                    return View("Index", model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Shedule/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Description")]Schedule shedule, string content)
        {
            if (shedule != null)
            {
                    shedule.Description = content;

                    db.Entry(shedule).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Shedule/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Schedule shedule = db.Schedule.FirstOrDefault(p => p.id == id);
            db.Schedule.Remove(shedule);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
    }
}
