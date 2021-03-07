using System;
using System.Net.Http;

namespace console_app
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            var result = client.GetAsync("https://localhost:5001/Products").Result;

            Console.Write(result);
        }
    }
}
