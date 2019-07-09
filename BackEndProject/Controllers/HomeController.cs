using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BackEndProject.Controllers
{
    
    public class HomeController : Controller
    {
        
        ClubDB db = new ClubDB();
        [Authorize]
        public ActionResult Index()
        {
            HomeVM model = new HomeVM()
            {
                users = db.Users.ToList(),
                events = db.Events.ToList(),
                trainers = db.Trainers.ToList(),
                course = db.Course.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            SystemUsers model = new SystemUsers();
            return View(model);
        }

        [HttpPost]
        public ActionResult SignIn(SystemUsers sys)
        {
            if(sys != null)
            {
                SystemUsers user = db.SystemUsers.FirstOrDefault(us => us.Email == sys.Email && us.Password == sys.Password);

                if(user != null)
                {
                    FormsAuthentication.SetAuthCookie(sys.Email, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}