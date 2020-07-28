using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaTecnica.Helpers;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaTecnica.Controllers
{
    public class BooksController : ApiController
    {
        // GET api/books
        public IHttpActionResult Get()
        {
            ApiHelper apiBooks = new ApiHelper();
            string bookjson = apiBooks.GetBooks();
            
            try
            {
                //CrearObjeto
                JArray arrayBook = JArray.Parse(bookjson);
                IList<Book> BooksList = arrayBook.ToObject<IList<Book>>();

                return Ok(BooksList);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // GET api/books/5
        public IHttpActionResult Get(int id)
        {
            ApiHelper apiBooks = new ApiHelper();
            string bookjson = apiBooks.GetBook(id);

            try
            {
                //CrearObjeto
                dynamic objc = JObject.Parse(bookjson);
                Book Modelo = objc.ToObject<Book>();
                return Ok(Modelo);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST api/books
        public IHttpActionResult Get(Book Libro)
        {
            ApiHelper apiBooks = new ApiHelper();
            string bookjson = apiBooks.PostBook(Libro);

            try
            {
                //CrearObjeto
                dynamic objc = JObject.Parse(bookjson);
                Book Modelo = objc.ToObject<Book>();
                return Ok(Modelo);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }



    }
}
