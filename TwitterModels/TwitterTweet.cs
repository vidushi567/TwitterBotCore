using System;
using Newtonsoft.Json;
namespace TwitterBotCore.TwitterModels
{
    public class TwitterTweet
    {
        [JsonProperty("created_at")]
        public string CreatedAt;

        [JsonProperty("id")]
        public long? Id;

        [JsonProperty("id_str")]
        public string Idstr;

        [JsonProperty("text")]
        public string Text;

        [JsonProperty("source")]
        public string Source;

        [JsonProperty("truncated")]
        public bool Truncated;

        [JsonProperty("in_reply_to_status_id")]
        public long? InReplyToStatusId;

        [JsonProperty("in_reply_to_status_id_str")]
        public string InReplyToStatusIdStr;

        [JsonProperty("in_reply_to_user_id")]
        public long? InReplyToUserId;

        [JsonProperty("in_reply_to_user_id_str")]
        public string InReplyToUserIdStr;

        [JsonProperty("in_reply_to_screen_name")]
        public string InReplyToScreenName;

        [JsonProperty("user")]
        public TwitterUser User;

        [JsonProperty("coordinates")]
        public Coordinates Coordinates;

        [JsonProperty("place")]
        public TwitterPlace Place;

        [JsonProperty("quoted_status_id")]
        public long? QuotedStatusId;

        [JsonProperty("quoted_status_id_str")]
        public string QuotedStatusIdStr;

        [JsonProperty("is_quote_status")]
        public bool IsQuoteStatus;

        [JsonProperty("quoted_status")]
        public TwitterTweet QuotedStatus ;

        [JsonProperty("retweeted_status")]
        public TwitterTweet RetweetedStatus;

        [JsonProperty("retweet_count")]
        public int? RetweetCount;

        [JsonProperty("favorite_count")]
        public int? FavoriteCount;

        [JsonProperty("entities")]
        public TweetEntities Entities;

        //extended_entities   Extended Entities

        [JsonProperty("favorited")]
        public bool Favorited;

        [JsonProperty("retweeted")]
        public bool Retweeted;

        [JsonProperty("possibly_sensitive")]
        public bool PossiblySensitive;

        [JsonProperty("filter_level")]
        public string FilterLevel;

        [JsonProperty("lang")]
        public string Lang;

    }
}
