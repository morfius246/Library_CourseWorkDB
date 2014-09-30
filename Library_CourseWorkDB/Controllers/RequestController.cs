﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_CourseWorkDB.Models;

namespace Library_CourseWorkDB.Controllers
{
    public class RequestController : Controller
    {
        private HomeContext db = new HomeContext();

        //
        // GET: /Request/

        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.ConfirmedRequest).Include(r => r.ReadingCard).Include(r => r.BookCopy).Include(r => r.RequestType);
            return View(requests.ToList());
        }

        //
        // GET: /Request/Details/5

        public ActionResult Details(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // GET: /Request/Create

        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.ConfirmedRequests, "RequestID", "RequestID");
            ViewBag.ReadingCardID = new SelectList(db.ReadingCards, "ID", "Name");
            ViewBag.InventNumberID = new SelectList(db.BookCopies, "InventaryNumber", "InventaryNumber");
            ViewBag.RequestTypeID = new SelectList(db.RequestTypes, "ID", "Name");
            return View();
        }

        //
        // POST: /Request/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.ConfirmedRequests, "RequestID", "RequestID", request.ID);
            ViewBag.ReadingCardID = new SelectList(db.ReadingCards, "ID", "Name", request.ReadingCardID);
            ViewBag.InventNumberID = new SelectList(db.BookCopies, "InventaryNumber", "InventaryNumber", request.InventNumberID);
            ViewBag.RequestTypeID = new SelectList(db.RequestTypes, "ID", "Name", request.RequestTypeID);
            return View(request);
        }

        //
        // GET: /Request/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.ConfirmedRequests, "RequestID", "RequestID", request.ID);
            ViewBag.ReadingCardID = new SelectList(db.ReadingCards, "ID", "Name", request.ReadingCardID);
            ViewBag.InventNumberID = new SelectList(db.BookCopies, "InventaryNumber", "InventaryNumber", request.InventNumberID);
            ViewBag.RequestTypeID = new SelectList(db.RequestTypes, "ID", "Name", request.RequestTypeID);
            return View(request);
        }

        //
        // POST: /Request/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.ConfirmedRequests, "RequestID", "RequestID", request.ID);
            ViewBag.ReadingCardID = new SelectList(db.ReadingCards, "ID", "Name", request.ReadingCardID);
            ViewBag.InventNumberID = new SelectList(db.BookCopies, "InventaryNumber", "InventaryNumber", request.InventNumberID);
            ViewBag.RequestTypeID = new SelectList(db.RequestTypes, "ID", "Name", request.RequestTypeID);
            return View(request);
        }

        //
        // GET: /Request/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // POST: /Request/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}