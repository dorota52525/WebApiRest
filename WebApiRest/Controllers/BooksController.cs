using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRest.Models;

namespace WebApiRest.Controllers
{
    public class BooksController : ApiController
    {
        private static List<Book> books = new List<Book>
        {
            new Book {Id = 1, Title = "Potop", Author = "H.Sienkiewicz", PublicationYear = 2010},
            new Book {Id = 2, Title = "Zemsta", Author = "A.Fredro", PublicationYear = 2003},
            new Book {Id = 3, Title = "Pan Tadeusz", Author = "A.Mickiewicz", PublicationYear = 2004},
            new Book {Id = 4, Title = "Romeo i Julia", Author = "W.Szekspir", PublicationYear = 2007},
        };

        // GET: api/books
        public List<Book> Get()
        {
            return books;
        }

        // GET: api/books/{id}
        public IHttpActionResult Get(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return  NotFound();
            }
            return Ok(book);
        }

        // POST: api/books
        public IHttpActionResult Post(Book book)
        {
            if (book == null || books.Any(x => x.Id == book.Id))
            {
                return BadRequest();
            }
            books.Add(book);

            return StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/books/{id}
        public IHttpActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            books.Remove(book);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT: api/books/{id}
        
    }
}
