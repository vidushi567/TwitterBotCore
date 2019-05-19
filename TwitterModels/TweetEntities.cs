using System;
using Newtonsoft.Json;

namespace TwitterBotCore.TwitterModels
{
    public class HashTags
    {
        [JsonProperty("indices")]
        public int[] Indices;

        [JsonProperty("text")]
        public string Text;
    }
    public class Size
    {
        [JsonProperty("w")]
        public int? W;
        [JsonProperty("h")]
        public int? H;
        [JsonProperty("resize")]
        public string Resize;
    }
    public class Media
    {
        [JsonProperty("display_url")]
        public string DisplayUrl;

        [JsonProperty("expanded_url")]
        public string ExpandedUrl;

        [JsonProperty("id")]
        public long? Id;

        [JsonProperty("id_str")]
        public string IdStr;

        [JsonProperty("indices")]
        public int[] Indices;

        [JsonProperty("media_url")]
        public string MediaUrl;

        [JsonProperty("media_url_https")]
        public string MediaUrlHttps;

        ///sizes Size Object

        [JsonProperty("source_status_id")]
        public long? SourceStatusId;

        [JsonProperty("source_status_id_str")]
        public long? SourceStatusIdStr;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("url")]
        public string Url;
    }

    public class Url
    {
        [JsonProperty("display_url")]
        public string DisplayUrl;

        [JsonProperty("expanded_url")]
        public string ExpandedUrl;

        [JsonProperty("indices")]
        public int[] Indices;

        [JsonProperty("url")]
        public string tweetUrl;
    }
    public class UserMention
    {
        [JsonProperty("id")]
        public long? Id;

        [JsonProperty("id_str")]
        public string IdStr;

        [JsonProperty("indices")]
        public int[] Indices;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("screen_name")]
        public string ScreenName;
    }

    public class Symbol
    {
        [JsonProperty("indices")]
        public int[] Indices;

        [JsonProperty("text")]
        public string text;
    }
    public class TweetEntities
    {
        [JsonProperty("hashtags")]
        public HashTags[] HashTags;

        [JsonProperty("media")]
        public Media[] Media;

        [JsonProperty("urls")]
        public Url[] Urls;

        [JsonProperty("user_mentions")]
        public UserMention[] UserMentions;

        [JsonProperty("symbols")]
        public Symbol[] Symbols;

        public TweetEntities()
        {
        }
    }
}
