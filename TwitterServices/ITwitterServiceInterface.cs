using System.Collections.Generic;

namespace TwitterBotCore.TwitterServices
{
    public interface ITwitterServiceInterface
    {
        void PostTweet(string tweetText,string twitterHandle,string tweetId);

        string GetTweets(string twitterHandle);

        string GetUserTimeLine(Dictionary<string,string> parameters);

        void Retweet(string tweetId);

        string GetMentionTimeLine(int count);

        void LikeTweet(string tweetId);
    }
}
