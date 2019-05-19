using System;
using System.Net.Http;

namespace TwitterBotCore.HttpRequestProxy
{
    public interface IRequestInterface
    {
        string SendRequest(string fullUrl, string oAuthHeader = null, FormUrlEncodedContent formData = null);
    }
}
