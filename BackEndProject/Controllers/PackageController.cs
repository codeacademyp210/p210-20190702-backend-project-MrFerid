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
    public class PackageController : Controller
    {
        ClubDB db = new ClubDB();
        // GET: Package
        public ActionResult Index()
        {
            PackageVM model = new PackageVM()
            {
                package = new Package(),
                packages = db.Package.ToList(),
                Action = "Create",
                Button = "Add"
            };
            return View(model);
        }

        // POST: Package/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Description")]Package Package,string content, HttpPostedFileBase file)
        {
            if(Package != null)
            {
                    if (file != null)
                    {
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                        file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                        Package.Image = fileName;
                    }

                    Package.Description = content;
                    db.Package.Add(Package);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }

        }

        // GET: Package/Edit/5
        public ActionResult Edit(int id)
        {
            Package pack = db.Package.FirstOrDefault(p => p.id == id);
            if(pack != null)
            {
                PackageVM model = new PackageVM()
                {
                    package = pack,
                    packages = db.Package.ToList(),
                    Action = "Edit",
                    Button = "Edit"
                };
                return View("Index", model);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        // POST: Package/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Description")]Package Package, string content, HttpPostedFileBase file)
        {
            if (Package != null)
            {
                Package.Description = content;
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    Package.Image = fileName;
                    db.Entry(Package).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(Package).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Package).Property(p=> p.Image).IsModified = false;
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
            Package package = db.Package.FirstOrDefault(p => p.id == id);
            db.Package.Remove(package);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
    }
}
