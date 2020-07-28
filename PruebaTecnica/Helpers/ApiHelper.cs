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
        //Post
        public string PostBook(Book book)
        {
            var client = new RestClient(ApiUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=cb4308daf0949850fad2bc32568054bec0fe12274c3f98e30180df1cb3df6576");
            //request.AddParameter("application/json", "{\n  \"ID\": 0,\n  \"Title\": \"string\",\n  \"Description\": \"string\",\n  \"PageCount\": 0,\n  \"Excerpt\": \"string\",\n  \"PublishDate\": \"2020-07-28T16:03:15.075Z\"\n}", ParameterType.RequestBody);
            request.AddParameter("application/json", "{\"ID\":"+ book.ID +",\"Title\":\"" + book.Title + "\",\"Description\":\"" + book.Description + "\",\"PageCount\":" + book.PageCount + ",\"Excerpt\":\"" + book.Excerpt + "\",\"PublishDate\":\"" + book.PublishDate + "\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
        //Put
        public string PutBook(int bookId, Book book)
        {
            var client = new RestClient(ApiUrl + "/" + bookId);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=cb4308daf0949850fad2bc32568054bec0fe12274c3f98e30180df1cb3df6576");
            //request.AddParameter("application/json", "{\n  \"ID\": 0,\n  \"Title\": \"string\",\n  \"Description\": \"string\",\n  \"PageCount\": 0,\n  \"Excerpt\": \"string\",\n  \"PublishDate\": \"2020-07-28T16:03:15.075Z\"\n}", ParameterType.RequestBody);
            request.AddParameter("application/json", "{\"ID\":" + book.ID + ",\"Title\":\"" + book.Title + "\",\"Description\":\"" + book.Description + "\",\"PageCount\":" + book.PageCount + ",\"Excerpt\":\"" + book.Excerpt + "\",\"PublishDate\":\"" + book.PublishDate + "\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
        //Delete
        public string DeleteBook(int bookId)
        {
            var client = new RestClient(ApiUrl + "/" + bookId);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Cookie", "ARRAffinity=cb4308daf0949850fad2bc32568054bec0fe12274c3f98e30180df1cb3df6576");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

    }
}