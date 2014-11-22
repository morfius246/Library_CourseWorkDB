using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Library_CourseWorkDB.BAL;
using Library_CourseWorkDB.Models;
using Rotativa;

namespace Library_CourseWorkDB.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private HomeContext db = new HomeContext();

        //
        // GET: /Request/

        public ActionResult Index()
        {
            var requests = db.Requests.Where(r=>r.ConfirmedRequest==null).Include(r => r.ConfirmedRequest).Include(r => r.ReadingCard).Include(r => r.BookCopy).Include(r => r.RequestType);
            return View(requests.ToList());
        }

        public ActionResult Confirmed()
        {
            var requests = db.ConfirmedRequests;
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

        public ActionResult Create(int bookId = 0, string type = "none")
        {
            Book book = db.Books.Find(bookId);
            RequestType requestType = db.RequestTypes.FirstOrDefault(r => r.Name == type);
            ReadingCard readingCard = db.ReadingCards.First(r => r.Name == User.Identity.Name);//change name for passport or login or phone number

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
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }

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
        public ActionResult Confirm(Request request, string selectedDuration)
        {
            int durationInMonthes;
            BookCopy bookCopy = db.BookCopies.Find(request.InventNumberID);
            if (!int.TryParse(selectedDuration, out durationInMonthes) || durationInMonthes<0 || durationInMonthes>6 || bookCopy == null)
            {
                return HttpNotFound();
            }
            ConfirmedRequest confirmedRequest = new ConfirmedRequest(request.ID, durationInMonthes);

            request = db.Requests.Find(request.ID);
            if (request.RequestType.Name == "take")
                bookCopy.StatusID = db.Statuses.FirstOrDefault(s => s.Name == "givenAway").ID;
            else if (request.RequestType.Name == "read")
                bookCopy.StatusID = db.Statuses.FirstOrDefault(s => s.Name == "readingRoom").ID;
            db.Entry(bookCopy).State = EntityState.Modified;
            db.ConfirmedRequests.Add(confirmedRequest);
            db.SaveChanges();



            return PartialView("SuccessPartial");
        }

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

        public ActionResult GetPdf(string pdfName)
        {
            return File(PdfManager.AppPath+"\\Pdf\\"+"test.pdf", "application/pdf");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}