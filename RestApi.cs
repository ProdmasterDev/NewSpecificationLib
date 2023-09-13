using Newtonsoft.Json;
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
    }
}
