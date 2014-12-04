using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using Library_CourseWorkDB.BAL;
using Library_CourseWorkDB.Models;
using Org.BouncyCastle.Ocsp;
using Rotativa;
using Library_CourseWorkDB.Filters;

namespace Library_CourseWorkDB.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class RequestController : Controller
    {
        private HomeContext db = new HomeContext();

        //
        // GET: /Request/
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Index()
        {
            var requests = db.Requests.Where(r=>r.ConfirmedRequest==null).Include(r => r.ConfirmedRequest).Include(r => r.ReadingCard).Include(r => r.BookCopy).Include(r => r.RequestType);
            return View(requests.ToList());
        }
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Confirmed(string sort)
        {
            List<ConfirmedRequest> requests = new List<ConfirmedRequest>();
            ViewBag.overduedSort = sort == "overdued_asc" ? "overdued_desc" : "overdued_asc";
            ViewBag.bookSort = sort == "book_asc" ? "book_desc" : "book_asc";
            ViewBag.inventaryNSort = sort == "inventaryN_asc" ? "inventaryN_desc" : "inventaryN_asc";
            ViewBag.reader = sort == "reader_asc" ? "reader_desc" : "reader_asc";
            ViewBag.giveAwayDateSort = sort == "giveAwayDate_asc" ? "giveAwayDate_desc" : "giveAwayDate_asc";
            ViewBag.returnDateSort = sort == "return_asc" ? "return_desc" : "return_asc";

            switch (sort)
            {
                case "overdued_asc":
                    requests = db.ConfirmedRequests.OrderBy(cr => cr.ReturnDate).ToList();
                    break;
                case "overdued_desc":
                    requests = db.ConfirmedRequests.OrderByDescending(cr => cr.ReturnDate).ToList();
                    break;
                case "book_asc":
                     requests = db.ConfirmedRequests.OrderBy(cr => cr.Request.BookCopy.Book.Name).ToList();
                    break;
                case "book_desc":
                    requests = db.ConfirmedRequests.OrderByDescending(cr => cr.Request.BookCopy.Book.Name).ToList();
                    break;
                case "inventaryN_asc":
                    requests = db.ConfirmedRequests.OrderBy(cr => cr.Request.BookCopy.InventaryNumber).ToList();
                    break;
                case "inventaryN_dessc":
                    requests = db.ConfirmedRequests.OrderByDescending(cr => cr.Request.BookCopy.InventaryNumber).ToList();
                    break;
                case "reader_asc":
                    requests = db.ConfirmedRequests.OrderBy(cr => cr.Request.ReadingCard.SecondName).ToList();
                    break;
                case "reader_desc":
                    requests = db.ConfirmedRequests.OrderByDescending(cr => cr.Request.ReadingCard.SecondName).ToList();
                    break;
                case "giveAwayDate_asc":
                    requests = db.ConfirmedRequests.OrderBy(cr => cr.GiveAwayDate).ToList();
                    break;
                case "giveAwayDate_desc":
                    requests = db.ConfirmedRequests.OrderByDescending(cr => cr.GiveAwayDate).ToList();
                    break;
                case "return_asc":
                    requests = db.ConfirmedRequests.OrderBy(cr => cr.ReturnDate).ToList();
                    break;
                case "return_desc":
                    requests = db.ConfirmedRequests.OrderByDescending(cr => cr.ReturnDate).ToList();
                    break;
                default: requests = db.ConfirmedRequests.ToList();
                    break;
            }

            
            return View(requests);
        }
        //
        // GET: /Request/Details/5
       /* [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Details(int id = 0)
        {
            Request request = db.Requests.Find(id);

            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }*/

        //
        // GET: /Request/Create
        public ActionResult Create(int bookId = 0, string type = "none")
        {
            Book book = db.Books.Find(bookId);
            RequestType requestType = db.RequestTypes.FirstOrDefault(r => r.Name == type);
            ReadingCard readingCard = db.ReadingCards.FirstOrDefault(r => r.PhoneNumber == User.Identity.Name);//change name for passport or login or phone number

            if (book == null || requestType == null || readingCard == null)
            {
                return HttpNotFound();
            }
            BookCopy bookCopy = book.BookCopies.First(bc => bc.Status.Name == "available");
            if (bookCopy == null)
            {
                return HttpNotFound();
            }

            var request = new Request
            {
                ReadingCard = readingCard,
                ReadingCardID = readingCard.ID,
                BookCopy = bookCopy,
                InventNumberID = bookCopy.InventaryNumber,
                RequestType = requestType,
                RequestTypeID = requestType.ID
            };

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Librarian, Student")]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                BookCopy bookCopy = db.BookCopies.FirstOrDefault(bc => bc.InventaryNumber == request.InventNumberID);
                bookCopy.Status = db.Statuses.FirstOrDefault(s => s.Name == "locked");

                db.Entry(bookCopy).State = EntityState.Modified;

                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(request);
        }

        [HttpPost]
        public ActionResult Delete(int id = 0)
        {
            Request request = db.Requests.Find(id);
            BookCopy bookCopy = request.BookCopy;
            Status availableStatus = db.Statuses.FirstOrDefault(s => s.Name == "available");

            if (request == null || bookCopy == null || availableStatus == null)
            {
                return HttpNotFound();
            }

            bookCopy.Status = availableStatus;
            db.Entry(bookCopy).State = EntityState.Modified;
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Confirm(int id = 0)
        {
            Request request = db.Requests.Find(id);

            if (request == null)
            {
                return HttpNotFound();
            }
            return PartialView("ConfirmPartial", request);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult Confirm(Request request, string selectedDuration)
        {
            int durationInMonthes;
            BookCopy bookCopy = db.BookCopies.Find(request.InventNumberID);
            request = db.Requests.Find(request.ID);
            if ((!int.TryParse(selectedDuration, out durationInMonthes) || durationInMonthes < 0 || durationInMonthes > 6 || bookCopy == null) && request.RequestType.Name != "read")
            {
                return HttpNotFound();
            }
            ConfirmedRequest confirmedRequest = new ConfirmedRequest(request.ID, durationInMonthes);

            
            if (request.RequestType.Name == "take")
                bookCopy.StatusID = db.Statuses.FirstOrDefault(s => s.Name == "givenAway").ID;
            else if (request.RequestType.Name == "read")
            {
                confirmedRequest = new ConfirmedRequest(request.ID);
                bookCopy.StatusID = db.Statuses.FirstOrDefault(s => s.Name == "readingRoom").ID;
            }
            db.Entry(bookCopy).State = EntityState.Modified;
            db.ConfirmedRequests.Add(confirmedRequest);
            db.SaveChanges();



            return PartialView("SuccessPartial");
        }

        public ActionResult Close(int id = 0)
        {
            ConfirmedRequest confirmedRequest = db.ConfirmedRequests.Find(id);
            Request request = null;
            BookCopy bookCopy = null;
            if (confirmedRequest != null)
            {
                request = db.Requests.Find(confirmedRequest.RequestID);
                if (request != null)
                {
                    bookCopy = db.BookCopies.Find(request.BookCopy.InventaryNumber);
                }
            }
            if (confirmedRequest == null || request == null || bookCopy == null)
            {
                return HttpNotFound();
            }
            bookCopy.Status = db.Statuses.FirstOrDefault(s => s.Name == "available");
            
            db.Entry(bookCopy).State = EntityState.Modified;
            db.Requests.Remove(request);
            db.ConfirmedRequests.Remove(confirmedRequest);
            db.SaveChanges();

            return RedirectToAction("Confirmed");
        }

        /*[Authorize(Roles = "Admin, Librarian")]
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
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/
        [Authorize(Roles = "Admin, Librarian")]
        public ActionResult GetPdf(string pdfName)
        {
            return File(PdfManager.AppPath+"\\Pdf\\"+"test.pdf", "application/pdf");
        }

        [Authorize(Roles = "Admin, Librarian")]
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}