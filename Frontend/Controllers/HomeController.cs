using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(int id=0)
        {
            if (id != 0)
            {
                string apiUrl = "https://localhost:44318/api/books/" + id;
                var httpClient = new HttpClient();
                var bookjson = await httpClient.GetStringAsync(apiUrl);
                dynamic objc = JObject.Parse(bookjson);
                Book Modelo = objc.ToObject<Book>();
                return View(Modelo);
            }
            else
            {
                string apiUrl = "https://localhost:44318/api/books";
                var httpClient = new HttpClient();
                var bookjson = await httpClient.GetStringAsync(apiUrl);
                JArray arrayBook = JArray.Parse(bookjson);
                IList<Book> BooksList = arrayBook.ToObject<IList<Book>>();
                ViewBag.BooksList = BooksList;
                return View();
            }
            
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(int id, Book Libro)
        {
            string apiUrl = "https://localhost:44318/api/books/" + id;
            var httpClient = new HttpClient();
            var bookjson = await httpClient.GetStringAsync(apiUrl);
            dynamic objc = JObject.Parse(bookjson);
            Book Modelo = objc.ToObject<Book>();
            return View(Modelo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Book Libro)
        {
            string apiUrl = "https://localhost:44318/api/books/" + id;
            var httpClient = new HttpClient();
            var bookjson = await httpClient.GetStringAsync(apiUrl);
            dynamic objc = JObject.Parse(bookjson);
            Book Modelo = objc.ToObject<Book>();
            return View(Modelo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}