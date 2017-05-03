using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EsmesCompany.Models;
using System.Data.Entity;
using EsmesCompany.Helper;

namespace EsmesCompany.Controllers
{
    public class AdminController : Controller
    {
        private EsmesContext db = new EsmesContext();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (!ModelState.IsValid)
            {
                using ( EsmesContext db = new EsmesContext())
                {
                    var obj = db.Users.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["Username"] = obj.Username.ToString();
                        return RedirectToAction("List");
                    }
                }
            }
            return View(user);
        }

       [CustomFilter]
        public ActionResult List()
        {
                IEnumerable<Subscription> yeni = db.Subscriptions.ToList();
                return View(yeni);
        }

        [CustomFilter]
        public ActionResult Logout()
        { 
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Login");
        }

        [CustomFilter]
        public ActionResult UyeEkle()
        {
            
                return View();
        }

        
        [HttpPost]
        public ActionResult UyeEkle(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [CustomFilter]
        public ActionResult SubscriptionAdd()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Fullname");
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearName");
            return View();
        }

        [CustomFilter]
        [HttpPost]
        public ActionResult SubscriptionAdd(Subscription sub)
        {
            try
            {
                db.Subscriptions.Add(sub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [CustomFilter]
        public ActionResult YearAdd()
        {
            return View();
        }

        [CustomFilter]
        [HttpPost]
        public ActionResult YearAdd(Year year)
        {
            try
            {
                db.Years.Add(year);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [CustomFilter]
        public ActionResult Edit(int id)
        {
            Subscription update = db.Subscriptions.Find(id);
            ViewBag.UserId = new SelectList(db.Users.Where(c => c.UserId == update.UserId), "UserId", "Fullname");
            ViewBag.YearId = new SelectList(db.Years.Where(c => c.YearId == update.YearId), "YearId", "YearName");

            return View(update);
        }

        [CustomFilter]
        [HttpPost]
        public ActionResult Edit(Subscription subs)
        {
            db.Entry(subs).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}