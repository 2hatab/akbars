using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace Akbars.Lessons
{
    public class HttpClient
    {
        public string Url { get; }

        public HttpClient(string url)
        {
            Url = url;
        }

        public T Execute<T>(IRestRequest request)
        {
            var client = new RestClient(Url);

            var response = client.Execute(request);

            return Deserialize<T>(response.Content);
        }

        private T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }

    public class Example
    {
        public string Name { get; set; }
    }

    public static class ExampleExtension
    {
        public static void SetName(this Example example, string name)
        {
            example.Name = $"Your name is {name}";

            Logger.GetLogger().Debug(example.Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunExample();
            RunHttpExample();
        }

        private static void RunHttpExample()
        {
            var httpClient = new HttpClient("http://localhost:8888");
            var response = httpClient.Execute<JObject>(new RestRequest("GetName"));

            var example = new Example();

            example.SetName(response["Name"].ToString());

            Console.ReadKey();
        }

        private static void RunExample()
        {
            var example = new Example();
            example.SetName("Timur");
            Console.ReadKey();
        }
    }
}
