using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;

namespace TranslateTextQuickStart
{
    class Program
    {
        static string host = "https://api.microsofttranslator.com";
        static string path = "/V2/Http.svc/Translate";

        // NOTE: Replace this example key with a valid subscription key.
        static string key = "48c0322f629c4f5cb61407b58e18b5e0";

        async static void TranslateText()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string> ("yes", "es-es"),
                //new KeyValuePair<string, string> ("Salut", "en-us")
            };

            foreach (KeyValuePair<string, string> i in list)
            {
                string uri = host + path + "?to=" + i.Value + "&text=" + System.Net.WebUtility.UrlEncode(i.Key);

                HttpResponseMessage response = await client.GetAsync(uri);

                string result = await response.Content.ReadAsStringAsync();
                // NOTE: A successful response is returned in XML. You can extract the contents of the XML as follows.
                var content = XElement.Parse(result).Value;
                Console.WriteLine(content);
            }
        }

        static void Main(string[] args)
        {
            TranslateText();
            Console.ReadLine();
        }
    }
}