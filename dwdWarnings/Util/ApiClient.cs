using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;

namespace dwdWarnings.Util
{
    internal class ApiClient
    {
        public static string API_URL = @"http://www.dwd.de/DWD/warnungen/warnapp/json/warnings.json";

        public static async Task<JObject> GetResponseAsync()
        {
            using (var client = new WebClient())
            {
                string response = await client.DownloadStringTaskAsync(API_URL);
                response = response.Substring(24);
                response = response.Substring(0, response.Length - 2);

                var parsedResponse = JObject.Parse(response);
                return parsedResponse;
            }
        }
    }
}
