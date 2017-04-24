﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EsmesCompany.Models;
using System.Data.Entity;

namespace EsmesCompany.Controllers
{
    public class HomeController : Controller
    {

        private EsmesContext db = new EsmesContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            if (Session["UserId"] != null) { 
                IEnumerable<Subscription> yeni = db.Subscriptions.ToList();
                return View(yeni);
            } else
            {
                //return RedirectToAction("Admin/Login");
                return RedirectToRoute("AdminLogin");
            }
        }

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

        public ActionResult SubscriptionAdd()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Fullname");
            ViewBag.YearId = new SelectList(db.Years, "YearId", "YearName");
            return View();
        }

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

        public ActionResult YearAdd()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            Subscription update = db.Subscriptions.Find(id);
            ViewBag.UserId = new SelectList(db.Users.Where(c => c.UserId == update.UserId), "UserId", "Fullname");
            ViewBag.YearId = new SelectList(db.Years.Where(c => c.YearId == update.YearId), "YearId", "YearName");
            
            return View(update);
        }

        [HttpPost]
        public ActionResult Edit(Subscription subs)
        {
            db.Entry(subs).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}