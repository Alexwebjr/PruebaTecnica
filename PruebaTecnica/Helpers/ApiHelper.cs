using Newtonsoft.Json;
using PruebaTecnica.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PruebaTecnica.Helpers
{
    public class ApiHelper
    {
       
            string ApiUrl = "https://fakerestapi.azurewebsites.net/api/Books";

        public string GetBooks()
        {
            var client = new RestClient(ApiUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "ARRAffinity=cb4308daf0949850fad2bc32568054bec0fe12274c3f98e30180df1cb3df6576");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
        public string GetBook(int bookId)
        {
            var client = new RestClient(ApiUrl+"/"+ bookId);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "ARRAffinity=cb4308daf0949850fad2bc32568054bec0fe12274c3f98e30180df1cb3df6576");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string PostBook(Book bookId)
        {
            var client = new RestClient(ApiUrl + "/" + bookId);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "ARRAffinity=cb4308daf0949850fad2bc32568054bec0fe12274c3f98e30180df1cb3df6576");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

    }
}