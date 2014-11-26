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
        Main model = new Main();
        [AllowAnonymous]
        public ActionResult Index(String categoryCode)
        {
            ReadingCard readingCard = Db.ReadingCards.Where(rc => rc.Name == "Borys").First();
            BookCopy bc =
                Db.BookCopies.Where(c => c.InventaryNumber == 2).Include(b => b.Book).Include(b => b.Book.UDC).First();
            PdfManager.GetReport("test", readingCard, bc);
            model.CategoryList = Db.UDCs.Where(x => x.Code == "0" || x.Code == "1" || x.Code == "2" || x.Code == "3" || x.Code == "4" || x.Code == "5" || x.Code == "6"
                || x.Code == "7" || x.Code == "8" || x.Code == "9").ToList();

            char categoryChar = ' ';
            if(categoryCode!=null) categoryChar = categoryCode[0];
            if(categoryCode!=null)
            {
                model.BookList = (from book in Db.Books where book.UDC.Code.Substring(0, 1) == categoryCode.Substring(0, 1) select book).ToList();
            }
            else
            {
                model.BookList = Db.Books.ToList();
            }
            return View(model);
        }
        public bool IsContainsLN(string searchString, Author author)
        {
            if (author.LastName != null)
            {
                if (author.LastName.ToUpper().Contains(searchString.ToUpper()))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public bool IsContainsSN(string searchString, Author author)
        {
            if (author.SecondName != null)
            {
                if (author.SecondName.ToUpper().Contains(searchString.ToUpper()))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public bool IsContainsN(string searchString, Author author)
        {
            if (author.Name != null)
            {
                if (author.Name.ToUpper().Contains(searchString.ToUpper()))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        [AllowAnonymous]
        public ActionResult Search(string searchBy, string searchString)
        {
                List<Book> books = Db.Books.ToList();
                List<Author> authors = Db.Authors.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    if(searchBy == "Title")
                    {
                        books = books.Where(x => x.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
                        return View(books.ToList()); 
                    }
                    else if (searchBy == "Author")
                    {
                        List<Book> booksA = new List<Book>();
                        foreach (var author in authors)
                        {
                            if (IsContainsLN(searchString, author) || IsContainsSN(searchString, author) || IsContainsN(searchString, author))
                                {
                                    foreach (var book in author.BooksList)
                                    {
                                        booksA.Add(book);
                                    }
                                }
                        }
                        return View(booksA.ToList());
                    }
                }
                return HttpNotFound();
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
    }
}
