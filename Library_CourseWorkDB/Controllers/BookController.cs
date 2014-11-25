using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using Library_CourseWorkDB.Models;
using Library_CourseWorkDB.Filters;
using WebGrease.Css.Extensions;

namespace Library_CourseWorkDB.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class BookController : Controller
    {
        private HomeContext db = new HomeContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
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


        [HttpGet]
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Create()
        {
            return View();
        }


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
                return RedirectToAction("Details", "Book", new { id = book.ID });
            }

            return View(book);
        }

        public ActionResult Authors(int id = 0)
        {
            if (id != 0)
            {
                Book book = db.Books.Where(b=>b.ID == id).Include(b=>b.AuthorsList).First();
                if (book != null)
                    return View(book);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult AddAuthor(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null) 
                return HttpNotFound();

            List<Author> authors = db.Authors.ToList();
            authors.RemoveAll(a => a.BooksList.Contains(book));

            List<SelectListItem> items = new List<SelectListItem>();
            authors.ForEach(a => 
            {
                items.Add(new SelectListItem()
                {
                    Text = a.GetShortName(),
                    Value = a.ID.ToString()
                });
            });

            ViewBag.author = items;
            ViewBag.bookId = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddAuthor(string author, int bookId)
        {
            Book book = db.Books.Find(bookId);
            Author curAuthor = null;

            int authorId;
            if (!int.TryParse(author, out authorId))
                return HttpNotFound("Invalid authorId input");
            else
            {
                curAuthor = db.Authors.Find(authorId);
                if (author == null) 
                    return HttpNotFound("Author not found");
            }

            if(!book.AuthorsList.Contains(curAuthor))
            {
                book.AuthorsList.Add(curAuthor);
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Edit", new { id = bookId });
        }

        public ActionResult RemoveAuthor(int id = 0, int bookId = 0)
        {
            Author author = db.Authors.Find(id);
            Book book = db.Books.Find(bookId);
            if (author == null || book == null)
            {
                return HttpNotFound("Author or Book not found in DB");
            }

            if (book.AuthorsList!=null && book.AuthorsList.Contains(author))
            {
                book.AuthorsList.Remove(author);
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Edit", new {id = bookId});
        }

        [ChildActionOnly]
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

            for (int i = 0; i < statuses.Count; i++)
                selectList.Add(new SelectListItem { Text = statuses[i].Name, Value = statuses[i].ID.ToString() });

            ViewBag.Statuses = selectList;
            return PartialView(book);
        }


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
            {
                ModelState.AddModelError("UDC.Code", "Невідомий УДК");
            }
            else
            {
                book.UDCID = db.UDCs.FirstOrDefault(u => u.Code == book.UDC.Code).ID;
                ModelState.SetModelValue("UDCID", new ValueProviderResult("",book.UDCID.ToString(), CultureInfo.CurrentCulture));
                ModelState.Remove("UDC");
                book.UDC = null;
            }

            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Book", new{id = book.ID});
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