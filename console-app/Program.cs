using System;
using System.Collections.Generic;
using System.Net.Http;

namespace console_app
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            var result1 = client.GetAsync("https://localhost:5001/Products").Result;
            var result2 = client.GetAsync("https://localhost:5001/Products/Featured").Result;
            var result3 = client.GetAsync("https://localhost:5001/Products/Categories").Result;
            var result4 = client.GetAsync("https://localhost:5001/Products/Electronics").Result;

            var resultList = new List<HttpResponseMessage>{
                result1,
                result2,
                result3,
                result4
            };

            foreach (var result in resultList)
            {
                Console.Write(result.Content.ReadAsStringAsync().Result + "\n");
            }
        }
    }
}
