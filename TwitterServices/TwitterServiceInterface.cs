using System.Configuration;
using System.Collections.Generic;
using TwitterBotCore.RequestHelpers;

namespace TwitterBotCore.TwitterServices
{
    public class TwitterServiceInterface:ITwitterServiceInterface
    {
        public TwitterServiceInterface()
        {
        }

        //TODO:Change all methods to use Dictionary as parameters

        public string GetTweets(string twitterHandle)
        {
            string Url = ConfigurationManager.AppSettings["TwitterBaseUrl"] + "/"+ ConfigurationManager.AppSettings["GetTweets"]; //https://api.twitter.com/1.1/search/tweets.json";

            var parameters = new Dictionary<string, string>();

            parameters.Add("q", "from:" + twitterHandle);

            var requestHelperObject = new RequestHelperDetails
            {
                RequestParamters = parameters,
                TwitterHandle = twitterHandle,
                RequestUrl = Url,
                HttpRequestMethod = RequestMethod.GET
            };
            var requestHelper = RequestHelperFactory.CreateRequestHelper(requestHelperObject);

            return requestHelper.SubmitRequest();           
        }

        public string GetMentionTimeLine(int count)
        {
            var Url = ConfigurationManager.AppSettings["TwitterBaseUrl"] + "/" + ConfigurationManager.AppSettings["GetMentionsTimeLine"];
            var parameters = new Dictionary<string, string>
            {
                {"count",count.ToString()}
            };
            var requestHelperObject = new RequestHelperDetails
            {
                RequestParamters = parameters,
                TwitterHandle = null,
                RequestUrl = Url,
                HttpRequestMethod = RequestMethod.GET
            };
            var requestHelper = RequestHelperFactory.CreateRequestHelper(requestHelperObject);

            return requestHelper.SubmitRequest();
        }

        public string GetUserTimeLine(Dictionary<string, string> parameters)//,string twitterHandle,int count)
        {
            var Url = ConfigurationManager.AppSettings["TwitterBaseUrl"] + "/" + ConfigurationManager.AppSettings["GetUserTimeLine"];
            /*
            var parameters = new Dictionary<string, string>
            {
                { "screen_name",twitterHandle },
                {"count",count.ToString()}
            };
            */
            var requestHelperObject = new RequestHelperDetails
            {
                RequestParamters = parameters,
                TwitterHandle = null,
                RequestUrl = Url,
                HttpRequestMethod = RequestMethod.GET
            };
            var requestHelper = RequestHelperFactory.CreateRequestHelper(requestHelperObject);

            return requestHelper.SubmitRequest();
        }

        public void Retweet(string tweetId)
        {
            var Url = ConfigurationManager.AppSettings["TwitterBaseUrl"] + "/" + string.Format(ConfigurationManager.AppSettings["Retweet"],tweetId);
            // $"https://api.twitter.com/1.1/statuses/retweet/{tweetId}.json";
            var parameters = new Dictionary<string, string>
            {
                { "id",tweetId },
                {"trim_user","1"}
            };
            var requestHelperObject = new RequestHelperDetails
            {
                RequestParamters = parameters,
                TwitterHandle = null,
                RequestUrl = Url,
                HttpRequestMethod = RequestMethod.POST
            };
            var requestHelper = RequestHelperFactory.CreateRequestHelper(requestHelperObject);

            var result =  requestHelper.SubmitRequest();
        }

        public void PostTweet(string text,string twitterHandle,string tweetId = null)
        {
            var Url = ConfigurationManager.AppSettings["TwitterBaseUrl"] + "/" + ConfigurationManager.AppSettings["PostTweets"];
            var parameters = new Dictionary<string, string>
            {
                { "status", text },
                { "trim_user", "1" }
            };
            if (tweetId != null)
                parameters.Add("in_reply_to_status_id",tweetId);
           
            var requestHelperObject = new RequestHelperDetails
            {
                RequestParamters = parameters,
                TwitterHandle = null,
                RequestUrl = Url,
                HttpRequestMethod = RequestMethod.POST
            };
            var requestHelper = RequestHelperFactory.CreateRequestHelper(requestHelperObject);

            var result = requestHelper.SubmitRequest();
        }

        public void LikeTweet(string tweetId)
        {
            var Url = ConfigurationManager.AppSettings["TwitterBaseUrl"] + "/" + ConfigurationManager.AppSettings["LikeTweet"];

            var parameters = new Dictionary<string, string>
            {
                { "id",tweetId },
                {"trim_user","1"}
            };
            var requestHelperObject = new RequestHelperDetails
            {
                RequestParamters = parameters,
                TwitterHandle = null,
                RequestUrl = Url,
                HttpRequestMethod = RequestMethod.POST
            };
            var requestHelper = RequestHelperFactory.CreateRequestHelper(requestHelperObject);

            var result = requestHelper.SubmitRequest();
        }
    }
}
