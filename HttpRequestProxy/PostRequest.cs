using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitterBotCore.HttpRequestProxy
{
    public static class PostRequest
    {
        public static string SendRequest(string fullUrl, string oAuthHeader, FormUrlEncodedContent formData)
        {
            var resp = SendRequestAsync(fullUrl, oAuthHeader, formData);
            resp.Wait();
            return resp.Result;
        }
        private static async Task<string> SendRequestAsync(string fullUrl, string oAuthHeader, FormUrlEncodedContent formData)
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("Authorization", oAuthHeader);

                var httpResp = await http.PostAsync(fullUrl, formData);
                var respBody = await httpResp.Content.ReadAsStringAsync();

                return respBody;
            }
        }
    }
}
