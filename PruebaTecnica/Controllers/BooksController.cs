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
            try
            {
                string bookjson = apiBooks.GetBooks();
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

            try
            {
                string bookjson = apiBooks.GetBook(id);
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
        [HttpPost]
        public IHttpActionResult Post(Book Libro)
        {
            ApiHelper apiBooks = new ApiHelper();

            try
            {
                string bookjson = apiBooks.PostBook(Libro);
                //CrearObjeto
                dynamic objc = JObject.Parse(bookjson);
                Book Modelo = objc.ToObject<Book>();
                return CreatedAtRoute("Get", new { id = Libro.ID }, Libro);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al agregar el libro");
            }
        }

        // PUT
        [HttpPut]
        public IHttpActionResult Put(int id, Book Libro)
        {
            ApiHelper apiBooks = new ApiHelper();

            try
            {
                string bookjson = apiBooks.PutBook(id, Libro);
                //CrearObjeto
                dynamic objc = JObject.Parse(bookjson);
                Book Modelo = objc.ToObject<Book>();
                return Ok(Modelo);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al actualizar el libro");
            }
        }

        // DELETE
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ApiHelper apiBooks = new ApiHelper();

            try
            {
                string bookjson = apiBooks.DeleteBook(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error al borrar el libro");
            }
        }

    }
}
