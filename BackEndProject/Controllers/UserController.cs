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
    public class UserController : Controller
    {
        ClubDB db = new ClubDB();
        // GET: User
        public ActionResult Index()
        {
            List<Users> model = db.Users.ToList();
            return View(model);
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if(id != null)
            {
                Users user = db.Users.FirstOrDefault(u => u.id == id);
                if(user != null)
                {
                    return View(user);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                Users user = db.Users.FirstOrDefault();
                return View(user);
            }
        }

        // GET: User/Create
        public ActionResult Modify()
        {
            UserVM model = new UserVM()
            {
                User = new Users(),
                Courses = db.Course.ToList(),
                Header = "Add user",
                Action = "Create"
            };
            return View("Modify", model);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(Users User, HttpPostedFileBase file)
        {
            if (User != null)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    User.Image = fileName;
                }

                User.RegisterDate = DateTime.Now;
                User.Status = "Offline";
                db.Users.Add(User);
                db.SaveChanges();
                return RedirectToAction("Modify");
            }
            else
            {
                return HttpNotFound();
            }

        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id != null)
            {
                Users user = db.Users.FirstOrDefault(u => u.id == id);
                UserVM model = new UserVM()
                {
                    User = user,
                    Courses = db.Course.ToList(),
                    Header = "Edit user",
                    Action = "Edit"
                };
                return View("Modify", model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(Users User, HttpPostedFileBase file)
        {
            if (User != null)
            {

                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    User.Image = fileName;
                    db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(User).Property(p => p.RegisterDate).IsModified = false;
                    db.Entry(User).Property(p => p.Status).IsModified = false;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(User).Property(p => p.Image).IsModified = false;
                    db.Entry(User).Property(p => p.RegisterDate).IsModified = false;
                    db.Entry(User).Property(p => p.Status).IsModified = false;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Users User = db.Users.FirstOrDefault(p => p.id == id);
            db.Users.Remove(User);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
        // GET: Payment
        public ActionResult Payment()
        {
            PaymentVM model = new PaymentVM()
            {
                users = db.Users.ToList(),
                courses = db.Course.ToList()
            };
            return View(model);
        }
    }
}
