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
    public class RoomController : Controller
    {
        ClubDB db = new ClubDB();
        // GET: Room
        public ActionResult Index()
        {
            RoomVM model = new RoomVM()
            {
                Room = new Room(),
                Rooms = db.Room.ToList(),
                Header = "Add Room",
                Action = "Create"
            };
            return View(model);
        }

        // GET: Room/Create
        [HttpPost]
        public ActionResult Create(Room Room)
        {
            if (ModelState.IsValid)
            {
                db.Room.Add(Room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                RoomVM model = new RoomVM()
                {
                    Room = new Room(),
                    Rooms = db.Room.ToList(),
                    Header = "Add Room",
                    Action = "Create"
                };
                return View("Index", model);
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Room rm = db.Room.FirstOrDefault(t => t.id == id);
                if (rm != null)
                {
                    RoomVM model = new RoomVM()
                    {
                        Room = rm,
                        Rooms = db.Room.ToList(),
                        Header = "Edit Room",
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

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Room Room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Room).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                RoomVM model = new RoomVM()
                {
                    Room = new Room(),
                    Rooms = db.Room.ToList(),
                    Header = "Edit Room",
                    Action = "Edit"
                };
                return View("Index", model);
            }
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Room rm = db.Room.FirstOrDefault(p => p.id == id);
            db.Room.Remove(rm);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
    }
}
