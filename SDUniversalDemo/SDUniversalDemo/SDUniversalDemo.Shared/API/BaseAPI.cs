using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
namespace SDUniversalDemo.API
{
    public class BaseAPI
    {


        public static async Task<string>  GetAsync(string url)
        {
            string content = string.Empty;
            HttpClient httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }) { Timeout = TimeSpan.FromSeconds(60) };
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            content = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(content);
        }

        private async Task<string> PostCall(string jsonData, string url, string methodName)
        {
            string content = string.Empty;
            try
            {
                HttpClient c = new HttpClient();
                c.BaseAddress = new Uri(url);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, methodName);
                req.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage obj = new HttpResponseMessage();
                await c.SendAsync(req).ContinueWith(respTask =>
                {
                    obj = respTask.Result;
                });

                content = await obj.Content.ReadAsStringAsync();
                return await Task.FromResult(content);
            }
            catch (Exception ex)
            {
                return "Exception";
            }
        }
        private static HttpClient GetHttpClient()
        {

            HttpClient httpclient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };

            httpclient.DefaultRequestHeaders.IfModifiedSince = DateTime.UtcNow;
            return httpclient;
        }
    }



    public class Request
    {
        public string Url { get; set; }
        public string Type { get; set; }
        public string Content_ { get; set; }
        public string url { get; set; }

    }
}
