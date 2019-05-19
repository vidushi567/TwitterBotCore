using System.Collections.Generic;
using TwitterBotCore.TwitterServices;

namespace TwitterBotCore.RequestHelpers
{
    public class RequestHelperDetails
    {
        public RequestHelperDetails()
        {
        }
        public Dictionary<string, string> RequestParamters { get; set; }

        public string RequestUrl { set; get; }

        public string TwitterHandle { set; get; }

        public RequestMethod HttpRequestMethod { set; get; }
    }
}
