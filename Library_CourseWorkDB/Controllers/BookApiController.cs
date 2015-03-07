using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library_CourseWorkDB.Models;

namespace Library_CourseWorkDB.Controllers
{
    public class BookApiController : ApiController
    {
        HomeContext db = new HomeContext();
        // GET api/<controller>
        public IEnumerable<BookModel> Get()
        {
            List<BookModel> transformedBooks = new List<BookModel>();
            foreach (var book in db.Books)
            {
                transformedBooks.Add(new BookModel(book));
            }
            return transformedBooks;
        }

        // GET api/<controller>/5
        public BookModel Get(int id)
        {
            Book book = db.Books.FirstOrDefault(b => b.ID == id);
            BookModel transformedBook = new BookModel(book);
            return transformedBook;
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]BookModel bookModel)
        {
            Book tranformedBook = new Book(bookModel);
            db.Books.Add(tranformedBook);
            db.SaveChanges();

            bookModel.ID = tranformedBook.ID;
            var response = Request.CreateResponse(HttpStatusCode.Created, bookModel);
            string url = Url.Link("DefaultApi", new { tranformedBook.ID });
            response.Headers.Location = new Uri(url);
            return response;
        }

        /*// PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            var deleteItem = db.Books.FirstOrDefault(b => b.ID == id);
            if (deleteItem != null)
            {
                db.Books.Remove(deleteItem);
                db.SaveChanges();
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, id);
            return response;
        }
    }
}