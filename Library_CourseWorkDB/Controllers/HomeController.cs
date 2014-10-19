using Library_CourseWorkDB.Models;
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

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
