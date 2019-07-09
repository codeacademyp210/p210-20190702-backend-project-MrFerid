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
    public class NewsController : Controller
    {
        ClubDB db = new ClubDB();
        // GET: News
        public ActionResult Index()
        {
            NewsVM model = new NewsVM()
            {
                News = db.News.ToList(),
                Package = db.Package.ToList()
            };           
            return View(model);
        }

        // GET: News/Create
        public ActionResult Modify()
        {
            NewsPackageVM model = new NewsPackageVM()
            {
                News = new News(),
                Package = db.Package.ToList(),
                Header = "Add News",
                Action = "Create",
                Button = "Add"
            };
            return View(model);
        }

        // POST: News/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Description")]News News,string content,HttpPostedFileBase file)
        {
            ModelState.Remove("Description");

            if (News != null)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    News.Image = fileName;
                }

                News.Description = content;
                db.News.Add(News);
                db.SaveChanges();
                return RedirectToAction("Modify");
            }
            else
            {
                NewsPackageVM model = new NewsPackageVM()
                {
                    News = new News(),
                    Package = db.Package.ToList(),
                    Header = "Add News",
                    Action = "Create",
                    Button = "Add"
                };
                return View("Modify", model);
            }

        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            News news = db.News.FirstOrDefault(p => p.id == id);
            if (news != null)
            {
                NewsPackageVM model = new NewsPackageVM()
                {
                    News = news,
                    Package = db.Package.ToList(),
                    Header = "Edit News",
                    Action = "Edit",
                    Button = "Edit"
                };
                return View("Modify", model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: News/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Description")]News News, string content, HttpPostedFileBase file)
        {
            if (News != null)
            {
                News.Description = content;
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    News.Image = fileName;
                    db.Entry(News).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(News).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(News).Property(p => p.Image).IsModified = false;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            News news = db.News.FirstOrDefault(p => p.id == id);
            db.News.Remove(news);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
    }
}
