using System;
using System.Net.Http;

namespace TwitterBotCore
{
    public class ReadTweets
    {
        private readonly string UserToReadTweets = "swamy39";
       // private readonly string ApiUrl = "https://api.twitter.com/";
       // private readonly string FQUrl = "1.1/search/tweets.json?oauth_consumer_key=lMrwESJ0lVfzH6BdwcWWfwjVo&oauth_signature_method=HMAC-SHA1&oauth_timestamp=1534563051&oauth_nonce=DJVERH&oauth_version=1.0&oauth_signature=IMLcsdkG%2Ftk4eaZ5vTKZ3QnPmG8%3D&q=from%3A" + UserToReadTweets;

        public ReadTweets()
        {
        }

       /* public string GetTweets()
        {
            string result;
            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = ApiUrl;
                httpClient.PostAsync();
            }
            return "";
        }
        */
    }
}
