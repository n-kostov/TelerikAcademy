using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetArticlesFromFeedzilla
{
    class Program
    {
        static async void PrintStudents(HttpClient httpClient, string query, string count)
        {
            var response = await httpClient.GetAsync(string.Format("articles/search.json?q={0}&count={1}", query, count));

            var result = response.Content.ReadAsAsync<FeedzillaResult>().Result;
            var articles = result.Articles;

            foreach (var article in articles)
            {
                Console.WriteLine("Title: {0}\nUrl: {1}", article.Title, article.Source_Url);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/v1/");
            httpClient.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));

            Console.Write("query = ");
            string query = Console.ReadLine();
            Console.Write("count = ");
            string count = Console.ReadLine();

            PrintStudents(httpClient, query, count);
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
