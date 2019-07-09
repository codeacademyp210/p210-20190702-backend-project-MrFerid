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
    public class EventController : Controller
    {
        ClubDB db = new ClubDB();
        // GET: Event
        public ActionResult Index()
        {
            EventVM model = new EventVM()
            {
                Event = new Event(),
                Events = db.Events.ToList(),
                Action = "Create",
                Button = "Add",
                Header = "Add Event"
            };
            return View(model);
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Event eve = db.Events.FirstOrDefault(e => e.id == id);
                if (eve != null)
                {
                    return View(eve);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                Event model = db.Events.FirstOrDefault();
                return View(model);
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Description")]Event Event, string content, HttpPostedFileBase file)
        {
            if (Event != null)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    Event.Image = fileName;
                }

                Event.Description = content;
                db.Events.Add(Event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }

        }

        // GET: Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id != null)
            {
                Event eve = db.Events.FirstOrDefault(ev => ev.id == id);
                if (eve != null)
                {
                    EventVM model = new EventVM()
                    {
                        Event = eve,
                        Events = db.Events.ToList(),
                        Action = "Edit",
                        Button = "Edit",
                        Header = "Edit Event"
                    };
                    return View("Index",model);
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

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Description")]Event Event, string content, HttpPostedFileBase file)
        {
            if (Event != null)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    Event.Image = fileName;
                    db.Entry(Event).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(Event).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Event).Property(p => p.Image).IsModified = false;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }

        }

        // POST: Package/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Event eve = db.Events.FirstOrDefault(p => p.id == id);
            db.Events.Remove(eve);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }


    }
}
