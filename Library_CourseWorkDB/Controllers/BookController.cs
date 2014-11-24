using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_CourseWorkDB.Models;
using Library_CourseWorkDB.Filters;

namespace Library_CourseWorkDB.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class BookController : Controller
    {
        private HomeContext db = new HomeContext();

        //
        // GET: /Book/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Book/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Book/Create
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Create(Book book)
        {
            if (!book.isDateValid())
                ModelState.AddModelError("EditionYear", "Невірна дата публікації");
            if (!book.UDC.IsValid(db))
                ModelState.AddModelError("UDC.Code", "Невідомий УДК");

            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(book);
        }
        [AllowAnonymous]
        public ActionResult CopyList(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return PartialView(book.BookCopies);
        }
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult CreateCopy(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return PartialView(null);
            }
            List<Status> statuses = db.Statuses.ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();

            for(int i = 0; i<statuses.Count;i++)
                selectList.Add(new SelectListItem {Text = statuses[i].Name, Value = statuses[i].ID.ToString()});

            ViewBag.Statuses = selectList;
            return PartialView(book);
        }

        //
        // POST: /Book/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult CreateCopy(BookCopy bookCopy)
        {
            if (ModelState.IsValid)
            {
                db.BookCopies.Add(bookCopy);
                db.SaveChanges();
                return RedirectToAction("Details", "Book", new { id = bookCopy.BookID });
            }

            return HttpNotFound();
        }

        //
        // GET: /Book/Edit/5
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Edit(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Edit(Book book)
        {
            if (!book.isDateValid())
                ModelState.AddModelError("EditionYear", "Невірна дата публікації");
            if (!book.UDC.IsValid(db))
                ModelState.AddModelError("UDC.Code", "Невідомий УДК");

            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(book);
        }
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult DeleteCopy(int id = 0)
        {
            string returnUrl = Request.UrlReferrer.AbsoluteUri;
            BookCopy bookCopy = db.BookCopies.Find(id);
            if (bookCopy == null)
            {
                return HttpNotFound();
            }
            db.BookCopies.Remove(bookCopy);
            db.SaveChanges();
            return Redirect(returnUrl);
        }
        
        // GET: /Book/Delete/5
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Delete(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}