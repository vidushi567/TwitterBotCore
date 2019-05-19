using System.Collections.Generic;
namespace TwitterBotCore.TwitterServices
{
    public class TwitterRequestObject
    {
        public string ConsumerKey;

        public string ConsumerKeySecret;

        public string AccessToken;

        public string AccessTokenSecret;

        public string TwitterHandle;

        public RequestMethod HttpRequestType;

        public Dictionary<string, string> QueryStringParams;
 
        public string Url;

        public TwitterRequestObject()
        {
        }
    }
}
