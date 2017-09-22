using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace APIPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://api.twitter.com/1.1/statuses/user_timeline.json";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var rawResponse = String.Empty;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            var twitter = JsonConvert.DeserializeObject<Twitter>(rawResponse);

            Console.WriteLine(twitter.screen_name);
        }
    }
}
