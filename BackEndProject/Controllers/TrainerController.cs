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
    public class TrainerController : Controller
    {
        ClubDB db = new ClubDB();
        // GET: Trainer
        public ActionResult Index()
        {
            TrainerVM model = new TrainerVM()
            {
                Trainer = new Trainers(),
                Trainers = db.Trainers.ToList(),
                Header = "Add Trainer",
                Action = "Create"
            };
            return View(model);
        }

        [HttpPost]
        // GET: Trainer/Create
        public ActionResult Create(Trainers Trainer)
        {
            if(ModelState.IsValid)
            {
                db.Trainers.Add(Trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TrainerVM model = new TrainerVM()
                {
                    Trainer = new Trainers(),
                    Trainers = db.Trainers.ToList(),
                    Header = "Add Trainer",
                    Action = "Create"
                };
                return View("Index",model);
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id != null)
            {
                Trainers tr = db.Trainers.FirstOrDefault(t => t.id == id);
                if(tr != null)
                {
                    TrainerVM model = new TrainerVM()
                    {
                        Trainer = tr,
                        Trainers = db.Trainers.ToList(),
                        Header = "Edit Trainer",
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
        // POST: Trainer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Trainers Trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Trainer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TrainerVM model = new TrainerVM()
                {
                    Trainer = new Trainers(),
                    Trainers = db.Trainers.ToList(),
                    Header = "Add Trainer",
                    Action = "Create"
                };
                return View("Index", model);
            }
        }


        // POST: Trainer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Trainers tr = db.Trainers.FirstOrDefault(p => p.id == id);
            db.Trainers.Remove(tr);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
    }
}
