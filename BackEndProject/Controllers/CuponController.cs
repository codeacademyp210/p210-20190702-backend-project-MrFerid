using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BackEndProject.Controllers
{
    [Authorize]
    public class CuponController : Controller
    {
        ClubDB db = new ClubDB();
        // GET: Cupon
        public ActionResult Index()
        {
            CuponVM model = new CuponVM()
            {
                Cupon = new Cupon(),
                Cupons = db.Cupon.ToList(),
                Action = "Create",
                Button = "Add",
                Header = "Add Cupon"
            };

            return View(model);
        }

        [ValidateInput(false)]
        // POST: Cupon/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Description")]Cupon Cupon, string content, HttpPostedFileBase file)
        {
            if (Cupon != null)
            {

                Cupon.Code = CodeBuilder(5);

                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    Cupon.Image = fileName;
                }

                Cupon.Description = content;
                db.Cupon.Add(Cupon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Cupon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Cupon cupon = db.Cupon.FirstOrDefault(p => p.id == id);
                if (cupon != null)
                {
                    CuponVM model = new CuponVM()
                    {
                        Cupon = cupon,
                        Cupons = db.Cupon.ToList(),
                        Action = "Edit",
                        Button = "Edit",
                        Header = "Edit Cupon"
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

        [ValidateInput(false)]
        // POST: Cupon/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Description")]Cupon Cupon, string content, HttpPostedFileBase file)
        {
            if (Cupon != null)
            {
                Cupon.Description = content;
               
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    Cupon.Image = fileName;
                    db.Entry(Cupon).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Cupon).Property(p => p.Code).IsModified = false;

                    db.SaveChanges();
                }
                else
                {
                    db.Entry(Cupon).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Cupon).Property(p => p.Image).IsModified = false;
                    db.Entry(Cupon).Property(p => p.Code).IsModified = false;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Cupon/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Cupon cupon = db.Cupon.FirstOrDefault(p => p.id == id);
            db.Cupon.Remove(cupon);
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }

        // Method creates code
        public string CodeBuilder(int n)
        {
            Random rnd = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            List<Cupon> cupons = db.Cupon.ToList();
            var builder = new StringBuilder();
            string code = "";

            do
            {
                for (var i = 0; i < n; i++)
                {
                        var c = pool[rnd.Next(0, pool.Length)];
                        builder.Append(c);
                }
                code = builder.ToString();
            }
            while (cupons.FirstOrDefault(c => c.Code == code) != null);
            return code.ToUpper();
        }
    }
}
