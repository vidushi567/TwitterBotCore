using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading;
using TwitterBotCore.TwitterModels;
using TwitterBotCore.LanguageHelpers;
using TwitterBotCore.TwitterServices;

namespace TwitterBotCore
{
    public class TwitterBot
    {
        private static TwitterServiceInterface _twitterService;

        public static TwitterServiceInterface TwitterSerivce => _twitterService ?? (_twitterService = new TwitterServiceInterface());

        private bool Initialize;
        public TwitterBot()
        {

        }

        public void Start()
        {
            Initialize = Convert.ToBoolean(ConfigurationManager.AppSettings["InitializeBot"]);
            while (true)
            {
                //TODO:Assign to variable and flip once initialized;
                //TODO:Make changes to automatically support addition of new users.
                //TODO:Make changes to support streaming;
                if (Initialize)
                {
                    InitializeBot();
                    Initialize = false;
                }
                var lines = ReadFile();
                var writeLines = new List<string>();
                foreach (var line in lines)
                {
                    var handleTweetIdMap = line.Split(',');
                    //var tweets = JArray.Parse(GetUserTimeLine(handleTweetIdMap[0], 0, handleTweetIdMap[1]));
                    var tweets = GetUserTimeLine(handleTweetIdMap[0], 0, handleTweetIdMap[1]);
                    var maxTweetId = Convert.ToInt64(handleTweetIdMap[1]);
                    var tweetList = new List<TwitterTweet>();
                    foreach (var tweet in tweets)
                    {
                        //var tweetId = tweet["id"].ToString();
                        var tweetId = tweet.Id.ToString();
                        if(tweet.RetweetedStatus == null)
                        {
                            if (maxTweetId < tweet.Id)
                            {
                                maxTweetId = tweet.Id.Value;
                                tweetList.Add(tweet);
                            }
                        }
                    }
                    if (maxTweetId > Convert.ToInt64(handleTweetIdMap[1]))
                    {
                        foreach(var tweet in tweetList)
                        {
                            Console.WriteLine("MaxTweetId = "+maxTweetId+" for user "+ handleTweetIdMap[0]);
                            Retweet(tweet.Id.ToString());
                            LikeTweets(tweet.Id.ToString());
                            TweetTranslation(tweet);
                        }
                    }
                    writeLines.Add(handleTweetIdMap[0] + "," + maxTweetId);
                }
                WriteToFile(writeLines.ToArray());
                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["SleepInterval"]));
            }
        }

        public void InitializeBot()
        {
            var twitterHandles = ConfigurationManager.AppSettings["TwitterHandles"].Split(',').ToList();
            List<string> oldTweetMap = new List<string>();
            foreach(var twitterHandle in twitterHandles)
            {
                var builder = new StringBuilder();
                var oldestTweet = GetOldestTweet(twitterHandle);
                builder.Append(twitterHandle);
                builder.Append(",");
                builder.Append(oldestTweet);
                oldTweetMap.Add(builder.ToString());
            }
            WriteToFile(oldTweetMap.ToArray());
        }

        private string GetOldestTweet(string twitterHandle)
        {
            var count = 10;
            var tweets = GetUserTimeLine(twitterHandle, count, null);
            //var tweetArr = JArray.Parse(tweets);
            //var tweetArr = JArray.Parse(tweets);
            var ids = tweets.Select(x => x.Id.ToString()).ToList();
            ids.Sort();
            return ids[0];
        }


        private List<TwitterTweet> GetUserTimeLine(string twitterHandle,int count,string pastTweetId)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("screen_name", twitterHandle);
            if (count >= 1)
                parameters.Add("count", count.ToString());
            if (pastTweetId != null)
                parameters.Add("since_id", pastTweetId);
            var tweets = JArray.Parse(TwitterSerivce.GetUserTimeLine(parameters));
            var result = tweets.Select(x => x.ToObject<TwitterTweet>()).ToList();
            return result;
        }
        private void Retweet(string tweetId)
        {
            //Console.WriteLine(tweetId);
            TwitterSerivce.Retweet(tweetId);

        }
        private void LikeTweets(string tweetId)
        {
            //Console.WriteLine(tweetId);
            TwitterSerivce.LikeTweet(tweetId);
        }
        private void WriteToFile(string[] lines)
        {
            File.WriteAllLines(ConfigurationManager.AppSettings["FilePathLocation"], lines);
        }
        private string[] ReadFile()
        {
            return File.ReadAllLines(ConfigurationManager.AppSettings["FilePathLocation"]);
        }
        public Tuple<List<string>,string> FormatTextForTranslation(string text)
        {
            var replacePeriod = text.Replace('.', ',');

            var splitText = replacePeriod.Split(' ');

            var list = new List<string>();

            var builder = new StringBuilder();

            foreach(var str in splitText)
            {
                if(str.Contains('@'))
                {
                    //builder.Append("{"+count+"}");
                    builder.Append("*");
                    //count++;
                    list.Add(str);
                }
                else
                {
                    builder.Append(str);
                }
                builder.Append(" ");
            }
            return new Tuple<List<string>, string>(list, builder.ToString());
        }

        public string CreateProperTranslatedText(List<string> handles,string text)
        {
            if (handles.Count < 1)
                return text;

            var splitTxt = text.Split(' ');

            var count = 0;

            var builder = new StringBuilder();

            foreach(var str in splitTxt)
            {
                if(str.Equals("*"))
                {
                    builder.Append(handles[count]);
                    count++;
                }
                else
                {
                    builder.Append(str);
                }
                builder.Append(" ");
            }

            //var result = string.Format(text, handles.ToArray());

            var result = builder.ToString();
                 
            return result;
        }
        public void TweetTranslation(TwitterTweet tweet)
        {
            if (tweet.Lang != LangMapHelper.LangMap["English"])
                return;

            var toBeTranslatedTuple = FormatTextForTranslation(tweet.Text);

            var translatedText = TranslationService.GetTranslation(LangMapHelper.LangMap["English"], LangMapHelper.LangMap["Hindi"], toBeTranslatedTuple.Item2);

            var fullyFormedTransation = "@"+tweet.User.ScreenName + " "+ CreateProperTranslatedText(toBeTranslatedTuple.Item1, translatedText);

            TwitterSerivce.PostTweet(fullyFormedTransation, null);

            translatedText = TranslationService.GetTranslation(LangMapHelper.LangMap["English"], LangMapHelper.LangMap["Gujarati"], toBeTranslatedTuple.Item2);

            fullyFormedTransation = "@" + tweet.User.ScreenName + " "+ CreateProperTranslatedText(toBeTranslatedTuple.Item1, translatedText);

            TwitterSerivce.PostTweet(fullyFormedTransation, null);
        }
    }
}
