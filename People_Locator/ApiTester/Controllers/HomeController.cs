using ApiTester.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ApiTester.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult MakeRequest(string url, string type, string[] data) 
        {
            HttpRequestMessage request = null;
            switch (type)
            {
                case "GET":
                    request = prepareGetRequest(url, data);
                    break;
                case "POST":
                    request = preparePostRequest(url, data);
                    break;
                case "PUT":
                    request = preparePutReqest(url, data);
                    break;
                case "DELETE":
                    request = prepareDeleteRequest(url, data);
                    break;
            }

            HttpResponseMessage response;
            Stopwatch sw = new Stopwatch();

            using (HttpClient client = new HttpClient())
            {
                sw.Start();
                response = client.SendAsync(request).Result;
                sw.Stop();
            }

            RequestViewModel model = new RequestViewModel();
            model.EllapsedMilliseconds = sw.ElapsedMilliseconds;
            model.Content = response.Content.ReadAsStringAsync().Result;
            model.Url = request.RequestUri.ToString();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        private HttpRequestMessage prepareGetRequest(string url, string[] data)
        {
            if (data != null)
            {
                return new HttpRequestMessage(HttpMethod.Get, url + "?" + convertToUrlParams(data));
            }
            else
            {
                return new HttpRequestMessage(HttpMethod.Get, url);
            }
        }

        private HttpRequestMessage preparePostRequest(string url, string[] data)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

            if (data != null)
            {
                string json = JsonConvert.SerializeObject(this.convertToNameValue(data));
                request.Content = new StringContent(json);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }

            return request;
        }

        private HttpRequestMessage preparePutReqest(string url, string[] data)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
            if (data != null)
            {
                request.Content = new FormUrlEncodedContent(this.convertToNameValue(data));
            }
            return request;
        }

        private HttpRequestMessage prepareDeleteRequest(string url, string[] data)
        {
            if (data != null)
            {
                return new HttpRequestMessage(HttpMethod.Delete, url + "?" + convertToUrlParams(data));
            }
            else
            {
                return new HttpRequestMessage(HttpMethod.Delete, url);
            }
        }

        private string convertToUrlParams(string[] data)
        {
            string[] connectors = { "=", "&" };
            string result = "";

            for (int i = 0; i < data.Length; i++)
            {
                result += data[i] + connectors[i % 2];
            }

            return result.Substring(0, result.Length - 1);
        }

        private Dictionary<string, string> convertToNameValue(string[] data)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            for (int i = 0; i < data.Length; i+=2)
            {
                pairs[data[i]] = data[i + 1];
            }

            return pairs;
        } 
    }
}