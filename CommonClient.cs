using System.Linq;
using System.Net.Http;

namespace NewSpecificationLib
{
    public abstract class CommonClient
    {
        public string ServerUrl { get; set; }
        protected HttpClient Client { get; set; } = new HttpClient();

        public CommonClient(string serverUrl)
        {
            ServerUrl = serverUrl;
            if (ServerUrl.Last() != '/') { ServerUrl += '/'; }
        }

        protected ResponseType GetData<ResponseType>(string uri)
        {
            return RestApi.GetData<ResponseType>(uri, Client);
        }

        protected ResponseType PostData<ResponseType, T>(string uri, T serializableObject)
        {
            return RestApi.PostData<ResponseType, T>(uri, serializableObject, Client);
        }

        protected ResponseType PatchData<ResponseType, T>(string uri, T serializableObject)
        {
            return RestApi.PatchData<ResponseType, T>(uri, serializableObject, Client);
        }
    }
}
