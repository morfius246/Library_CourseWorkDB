using System.Data.Entity;
using Library_CourseWorkDB.BAL;
using Library_CourseWorkDB.Filters;
using Library_CourseWorkDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_CourseWorkDB.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        protected HomeContext Db = new HomeContext();
        [AllowAnonymous]
        public ActionResult Index(String categoryCode, String searchString = "")
        {
            Main mainModel = new Main();
            mainModel.CategoryList = Db.UDCs.Where(x => x.Code == "0" || x.Code == "1" || x.Code == "2" || x.Code == "3" || x.Code == "4" || x.Code == "5" || x.Code == "6"
                || x.Code == "7" || x.Code == "8" || x.Code == "9").ToList();

            char categoryChar = ' ';
            if(categoryCode!=null) categoryChar = categoryCode[0];
            if(categoryCode!=null)
            {
                mainModel.BookList = (from book in Db.Books where book.UDC.Code.Substring(0, 1) == categoryCode.Substring(0, 1) select book).ToList();
            }
            else
            {
                mainModel.BookList = Db.Books.ToList();
            }
            return View(mainModel);
        }

        public ActionResult BookSearch(string searchBy, string searchString)
        {
            IEnumerable<Book> books = null;
            if (!String.IsNullOrWhiteSpace(searchString) && !String.IsNullOrWhiteSpace(searchBy))
            {
                if (searchBy == "Title")
                {
                    books = Db.Books.Where(x => x.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
                }
                else if (searchBy == "Author")
                {
                    books =
                        Db.Books.Where(
                            b =>
                                b.AuthorsList.FirstOrDefault(
                                    a =>
                                        a.Name.Contains(searchString) || a.SecondName.Contains(searchString) ||
                                        a.LastName.Contains(searchString)) != null).ToList();
                }
            }
            return PartialView("BookSearch", books);
        }

        public ActionResult AutoCompleteSearch(string term)
        {
            var authors =
                Db.Authors.Where(a => a.Name.Contains(term) || a.SecondName.Contains(term) || a.LastName.Contains(term)).ToList().Select(aa => new {value = aa.LastName});
            return Json(authors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Student(int id)
        {
            ReadingCard model = Db.ReadingCards.Find(id);
            return View(model.RequestsList);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult KnockOutDemo()
        {
            return View();
        }
    }
}
