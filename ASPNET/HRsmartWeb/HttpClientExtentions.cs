using Antlr.Runtime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace HRsmartWeb
{
    public class HttpClientExtentions
    {
        public static string GetToken(string url, string userName, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "password" ),
                        new KeyValuePair<string, string>( "username", userName ),
                        new KeyValuePair<string, string> ( "password", password )
                    };
            var content = new FormUrlEncodedContent(pairs);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url + "token", content).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        public static string  CallApi(string url, string token)
        {

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(token))
                {
                    var t = JsonConvert.DeserializeObject<Token>(token);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + t.access_token);
                }
                var response = client.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public HttpClientExtentions()
        {

        }
    }

}