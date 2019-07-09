using BackEndProject.DAL;
using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace BackEndProject.Controllers
{
    [Authorize]
    public class InfoController : Controller
    {
        ClubDB db = new ClubDB();
        // GET: Info
        public ActionResult Index()
        {
            Info firstInfo = db.Info.FirstOrDefault();
            Info model = (firstInfo == null) ? new Info() : firstInfo;
            return View(model);
        }

        // JSON: Edit / Info
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(string Conditions, string Username,string Email,string Number,string Address,string City,string Pincode,string Fax,string Website, int id)
        {
            Info inform = db.Info.FirstOrDefault(i=> i.id == id);

            if (Username != null)
            {
                inform.Username = Username;
                db.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            else if (Conditions != null)
            {
                inform.Conditions = Conditions.ToString();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (Email != null)
            {
                inform.Email = Email;
                db.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            else if (Number != null)
            {
                inform.Number = Number;
                db.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            else if (Address != null)
            {
                inform.Address = Address;
                db.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            else if (City != null)
            {
                inform.City = City;
                db.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            else if (Pincode != null)
            {
                inform.Pincode = Convert.ToInt32(Pincode);
                db.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            else if (Fax != null)
            {
                inform.Fax = Fax;
                db.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            else if (Website != null)
            {
                inform.Website = Website;
                db.SaveChanges();
                return new HttpStatusCodeResult(200);
            }
            else
            {
                return new HttpStatusCodeResult(400);
            }
        }

        
        public ActionResult Network([Bind(Include ="id,Facebook,Twitter,Google,Skype")] Info Info)
        {
            Info inform = db.Info.FirstOrDefault(i => i.id == Info.id);

            if(inform != null)
            {
                inform.Facebook = Info.Facebook;
                inform.Twitter = Info.Twitter;
                inform.Google = Info.Google;
                inform.Skype = Info.Skype;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // JSON: Add/Replace image
        [HttpPost]
        public JsonResult AddImage(HttpPostedFileBase file)
        {
            Info info = db.Info.FirstOrDefault();

            if (file != null)
            {
                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/img/" + FileName));
                info.Photo = FileName;
                db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }

        }

        // JSON: Remove image
        [HttpPost]
        public JsonResult RemoveImage()
        {
            Info info = db.Info.FirstOrDefault();
            if (info != null)
            {
                info.Photo = null;
                db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }


    }
}