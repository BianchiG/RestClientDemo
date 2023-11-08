using RestSharp;

namespace RestSharpClient.DataAccess
{
    public class RestClientWrapper
    {
        public static RestClient client { get; private set; }

        public static void RestClientInitialize()
        {
            string url = "https://localhost:7049/api/";
            client = new RestClient(url);
        }
    }
}
