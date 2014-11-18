﻿using Library_CourseWorkDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_CourseWorkDB.Controllers
{
    public class HomeController : Controller
    {
        protected HomeContext Db = new HomeContext();
        Main model = new Main();
        public ActionResult Index(String categoryCode)
        {
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

        public ActionResult Search(string searchBy, string searchString)
        {
            try
            {
                searchBy = searchBy == "Author" ? "Author" : "Title";
                List<Book> books = Db.Books.ToList();
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
                        foreach (var book in books)
                        {
                            foreach (var author in book.AuthorsList)
                            {
                                if (author.LastName.ToUpper().Contains(searchString.ToUpper()) ||
                                    author.SecondName.ToUpper().Contains(searchString.ToUpper()) ||
                                    author.Name.ToUpper().Contains(searchString.ToUpper()))
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
            catch
            {
                return HttpNotFound();
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
