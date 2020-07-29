using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Frontend.Models;
using Newtonsoft.Json;
using System.Text;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index(int? id)
        {
            if (id != null)
            {
                string apiUrl2 = "https://localhost:44318/api/books/" + id;
                var httpCliente = new HttpClient();
                var bookjs = await httpCliente.GetStringAsync(apiUrl2);
                dynamic objc = JObject.Parse(bookjs);
                Book Modelo = objc.ToObject<Book>();
                return View(Modelo);
            }
            else{

            }
                string apiUrl = "https://localhost:44318/api/books";
                var httpClient = new HttpClient();
                var bookjson = await httpClient.GetStringAsync(apiUrl);
                JArray arrayBook = JArray.Parse(bookjson);
                IList<Book> BooksList = arrayBook.ToObject<IList<Book>>();
                ViewBag.BooksList = BooksList;
                return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Book Libro)
        {
            //Set DateTime
            DateTime Publicado = Convert.ToDateTime(Libro.PublishDate);
            Libro.PublishDate = Publicado.ToString("yyyy-MM-ddTHH:mm:ss");

            string apiUrl = "https://localhost:44318/api/books";
            var httpClient = new HttpClient();

            //Serializar
            var json = JsonConvert.SerializeObject(Libro);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var bookjson = await httpClient.PostAsync(apiUrl, data);
            string result = bookjson.Content.ReadAsStringAsync().Result;

            dynamic objc = JObject.Parse(result);
            Book Modelo = objc.ToObject<Book>();
            return View(Modelo);
        }

        //Edit
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id)
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
        public async Task<ActionResult> Edit(Book Libro)
        {
                string apiUrl = "https://localhost:44318/api/books/" + Libro.ID;
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