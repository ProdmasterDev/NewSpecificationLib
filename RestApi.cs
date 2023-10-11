using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;

namespace NewSpecificationLib
{
    public static class RestApi
    {
        public static ResponseType GetData<ResponseType>(string uri, HttpClient client)
        {
            var response = client.GetStringAsync(uri);
            response.Wait();
           
            return JsonConvert.DeserializeObject<ResponseType>(response.Result);
        }

        public static ResponseType PostData<ResponseType, T>(string uri, T serializableObject, HttpClient client)
        {
            //client.PostAsJsonAsync(uri, serializableObject);
            var json = JsonConvert.SerializeObject(serializableObject);
            var requestData = new StringContent(json, Encoding.UTF8, "application/json");

            return PostJson<ResponseType>(uri, requestData, client);
        }

        private static ResponseType PostJson<ResponseType>(string uri, StringContent requestData, HttpClient client)
        {
            var response = client.PostAsync(uri, requestData);
            response.Wait();
            var responceRes = response.Result.Content.ReadAsStringAsync();
            responceRes.Wait();

            return JsonConvert.DeserializeObject<ResponseType>(responceRes.Result);
        }

        public static ResponseType PatchData<ResponseType, T>(string uri, T serializableObject, HttpClient client)
        {
            var jsonString = JsonConvert.SerializeObject(serializableObject);
            return PatchJson<ResponseType>(uri, jsonString, client);
        }

        private static ResponseType PatchJson<ResponseType>(string uri, string jsonString, HttpClient client)
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), uri)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(request);
            response.Wait();
            var responseRes = response.Result.Content.ReadAsStringAsync();
            responseRes.Wait();

            return JsonConvert.DeserializeObject<ResponseType>(responseRes.Result);
        }
    }
}
