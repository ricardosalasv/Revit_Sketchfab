using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab_Core.lib
{
    public class SketchfabAPIConnection
    {

        public HttpClient client = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public SketchfabAPIConnection()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://sketchfab.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = null;
            client.Timeout = new TimeSpan(0, 10, 0);
        }

        /// <summary>
        /// Executes a GET request to the specified endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task<string> ConnectionAsync(string endpoint)
        {

            HttpResponseMessage responseMessage = await client.GetAsync(new Uri(endpoint, UriKind.Relative));

            var result = await responseMessage.Content.ReadAsStringAsync();

            return result;

        }

        /// <summary>
        /// Authenticates the user by its username and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> Authenticate(string email, string password)
        {
            object contentObject = new
            {
                grant_type = "password",
                username = email,
                password = password
            };

            string content = JsonConvert.SerializeObject(contentObject);

            HttpContent postContent = new StringContent(content, Encoding.UTF8, "application/json");

            HttpResponseMessage sketchfabResponse = await client.PostAsync(new Uri("oauth2/token/", UriKind.Relative), postContent);

            if (sketchfabResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string sketchfabToken = await sketchfabResponse.Content.ReadAsStringAsync();
                sketchfabToken = sketchfabToken.ToString();
                sketchfabToken = sketchfabToken.Replace("(", String.Empty);
                sketchfabToken = sketchfabToken.Replace(")", String.Empty);
                sketchfabToken = sketchfabToken.Replace("{", String.Empty);
                sketchfabToken = sketchfabToken.Replace("}", String.Empty);
                sketchfabToken = sketchfabToken.Replace("\\", String.Empty);
                sketchfabToken = sketchfabToken.Replace(":", String.Empty);
                sketchfabToken = sketchfabToken.Replace("-", String.Empty);
                sketchfabToken = sketchfabToken.Replace("\"", String.Empty);
                sketchfabToken = sketchfabToken.Replace("value", String.Empty);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(sketchfabToken);

                return true;
            }

            return false;
        }

    }

    //public class LowerCaseNamingPolicy : JsonNamingPolicy
    //{
    //    public override string ConvertName(string name) => name.ToLower();
    //}
}
