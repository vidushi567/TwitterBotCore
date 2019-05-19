using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitterBotCore.HttpRequestProxy
{
    public static class GetRequest
    {
        public static string SendRequest(string url)
        {
            var resp = SendRequestAsync(url);

            resp.Wait();

            return resp.Result;
        }

        private static async Task<string> SendRequestAsync(string url)
        {
            using (var http = new HttpClient())
            {
                string result = string.Empty;
                try
                {
                    var httpResp = await http.GetAsync(url);
                    var res = httpResp.EnsureSuccessStatusCode();
                    result = await res.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    var message = e.Message;
                    return message;
                }
                return result;

            }
        }
    }
}
