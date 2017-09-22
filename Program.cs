using System;
using System.IO;
using System.Net;
using CoreTweet;
using Newtonsoft.Json;

namespace APIPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://api.twitter.com/1.1/statuses/user_timeline.json";
            var request = WebRequest.Create(url);
            request.Headers.Add("Authorization", "OAuth oauth_consumer_key=&quot;DC0sePOBbQ8bYdC8r4Smg&quot;,oauth_signature_method=&quot;HMAC-SHA1&quot;,oauth_timestamp=&quot;1506088026&quot;,oauth_nonce=&quot;2539863211&quot;,oauth_version=&quot;1.0&quot;,oauth_token=&quot;485132772-OotcSS719lvYjkg1iLi3Y0OQS8WsztdV1Ur6r5rP&quot;,oauth_signature=&quot;KVReoTIojMFP3XkyKsqoWap3L5A%3D&quot;");
            request.Headers.Add("Host", "api.twitter.com");
            request.Headers.Add("X-Target-URI", "https://api.twitter.com");
            request.Headers.Add("Connection", "Keep-Alive");
            var session = OAuth.AuthorizeAsync("yNJOvU1JtXR49nTBlyc64hqNw", "vMjhbBroJkFYg49L5TASbZeSWnoVUOphlhwTwQBJ2zAJ1diD9r").Result;
            Console.WriteLine(session.AuthorizeUri.AbsoluteUri);
            
           var tokens = OAuth.GetTokensAsync(session, "6829574").Result;
            try
            {
                var response = request.GetResponse();
                var rawResponse = String.Empty;

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    rawResponse = reader.ReadToEnd();
                }

                var twitter = JsonConvert.DeserializeObject<Twitter>(rawResponse);

                Console.WriteLine(twitter.screen_name);
            }

            catch (System.Exception ex)
            {
              
            }
        }
    }
}