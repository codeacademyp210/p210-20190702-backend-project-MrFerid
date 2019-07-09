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
    public class CourseController : Controller
    {
        
        ClubDB db = new ClubDB();
        // GET: Course
        public ActionResult Index()
        {
            CourseVM model = new CourseVM()
            {
                Course = new Course(),
                Courses = db.Course.ToList(),
                Header = "Add Course",
                Action = "Create"
            };
            return View(model);
        }

        // POST: Course/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Description")]Course Course, string content, HttpPostedFileBase file)
        {
            if (Course != null)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    Course.Image = fileName;
                }

                Course.Description = content;
                db.Course.Add(Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Course course = db.Course.FirstOrDefault(p => p.id == id);
                if (course != null)
                {
                    CourseVM model = new CourseVM()
                    {
                        Course = course,
                        Courses = db.Course.ToList(),
                        Action = "Edit",
                        Header = "Edit Course"
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

        // POST: Course/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Description")]Course Course, string content, HttpPostedFileBase file)
        {
            if (Course != null)
            {
                Course.Description = content;
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    Course.Image = fileName;
                    db.Entry(Course).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(Course).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Course).Property(p => p.Image).IsModified = false;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Course crs = db.Course.FirstOrDefault(p => p.id == id);
            db.Course.Remove(crs);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
    }
}
