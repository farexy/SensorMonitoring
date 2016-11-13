using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SensorMonitoring.SL.DTO;

namespace SL.Loader.HttpLoader
{
    internal class HttpLoader<T> : ILoader<T> where T : BaseDTO, new()
    {
        private string url;

        public HttpLoader(string baseAddress)
        {
            T item = new T();
            this.url = baseAddress + item.pathToActions;
        }

        private CUDResponseView sendCUDRequest(HttpRequestMessage req)
        {
            HttpResponseMessage res = null;

            using (HttpClient client = new HttpClient())
            {
                res = client.SendAsync(req).Result;
            }

            // checking if we don't get bool which is possible
            string content = res.Content.ReadAsStringAsync().Result.Trim();

            if (content == Boolean.TrueString || content == JsonConvert.True)
            {
                return CUDResponseView.BuildSuccessResponse();
            }
            else if (content == Boolean.FalseString || content == JsonConvert.False)
            {
                return CUDResponseView.BuildErrorResponse("");
            }

            return JsonConvert.DeserializeObject<CUDResponseView>(content);
        }

        public CUDResponseView DeleteItem(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Delete, this.url + "?id=" + id);
            return this.sendCUDRequest(req);
        }

        public IEnumerable<T> LoadAll()
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, this.url);
            HttpResponseMessage response = null;

            using (HttpClient client = new HttpClient())
            {
                response = client.SendAsync(req).Result;
            }

            string content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
        }

        public T LoadById(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, this.url + "?id=" + id);
            HttpResponseMessage response = null;

            using (HttpClient client = new HttpClient())
            {
                response = client.SendAsync(req).Result;
            }

            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public CUDResponseView PostItem(T item)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, this.url);

            req.Content = new StringContent(JsonConvert.SerializeObject(item));
            req.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.sendCUDRequest(req);
        }

        public CUDResponseView PutItem(T item)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put, this.url);

            req.Content = new StringContent(JsonConvert.SerializeObject(item));
            req.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return this.sendCUDRequest(req);
        }
    }
}
