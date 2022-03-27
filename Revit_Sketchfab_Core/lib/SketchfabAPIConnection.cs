using Newtonsoft.Json;
using Revit_Sketchfab_Core.lib.APIObjects;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<string> UploadModel(string modelFilePath, string modelName)
        {
            // Creating an object that will be serialized, which contains relevant data for the Sketchfab API
            Sketchfab_Model modelObject = new Sketchfab_Model(modelName);
            object uploadOptions = new
            {
                shading = "lit",
                orientation = new
                {
                    axis = new List<int>()
                    {
                        1, 0, 0
                    },
                    angle = 180
                }
            };

            try
            {
                // Reading our model from disk and creating a stream to it in order to add it to the POST request
                FileStream fileStream = new FileStream(modelFilePath, FileMode.Open, FileAccess.Read);

                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(modelObject.name), "name");
                formData.Add(new StringContent(JsonConvert.SerializeObject(modelObject.isInspectable)), "isInspectable");
                formData.Add(new StringContent(JsonConvert.SerializeObject(modelObject.tags)), "tags");
                formData.Add(new StringContent(JsonConvert.SerializeObject(modelObject.isPublished)), "isPublished");
                formData.Add(new StringContent(modelObject.description), "description");
                formData.Add(new StreamContent(fileStream), "modelFile", modelName + ".zip");
                formData.Add(new StringContent(JsonConvert.SerializeObject(uploadOptions)), "options");

                string test = await formData.ReadAsStringAsync();

                HttpResponseMessage responseMessage = await client.PostAsync(new Uri("https://api.sketchfab.com/v3/models", UriKind.Absolute), formData);

                var result = await responseMessage.Content.ReadAsStringAsync();

                fileStream.Close();

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return null;
        }

        /// <summary>
        /// Authenticates the user by its username and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> Authenticate(string email, string password)
        {
            string CLIENT_ID = Environment.GetEnvironmentVariable("SKTF_CLIENT_ID");
            string CLIENT_SECRET = Environment.GetEnvironmentVariable("SKTF_CLIENT_SECRET");

            string content = $"grant_type=password&username={email}&password={password}&client_id={CLIENT_ID}&client_secret={CLIENT_SECRET}";

            HttpContent postContent = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage sketchfabResponse = await client.PostAsync(new Uri("oauth2/token/", UriKind.Relative), postContent);

            if (sketchfabResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string sketchfabContent = await sketchfabResponse.Content.ReadAsStringAsync();
                AuthResponse response = JsonConvert.DeserializeObject<AuthResponse>(sketchfabContent);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(response.token_type, response.access_token);

                return true;
            }

            return false;
        }

    }


    public class AuthResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public string refresh_token { get; set; }
    }

}
