using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaApp.Models;

namespace CinemaApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (DBClass db = new DBClass())
            {
                return View(db.UserAccount.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Register(UserAccount account)
        {
            if(ModelState.IsValid)
            {
                using (DBClass db = new DBClass())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (DBClass db = new DBClass())
            {
                var usr = db.UserAccount.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password incorrect");
                }
                return View();
            }
        }
        public ActionResult LoggedIn()
            {
                if (Session["UserID"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        public ActionResult LoggedInAdmin()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult AddMovie()
        {
            return View();
        }
    }
}