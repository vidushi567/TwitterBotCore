using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace TwitterBotCore.TwitterModels
{
    public class TwitterUser
    {
        [JsonProperty("id")]
        public long? Id;

        [JsonProperty("id_str")]
        public string IdStr;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("screen_name")]
        public string ScreenName;

        [JsonProperty("location")]
        public string Location;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("protected")]
        public bool Protected;

        [JsonProperty("verified")]
        public bool Verified;

        [JsonProperty("followers_count")]
        public int? Followers_count;

        [JsonProperty("friends_count")]
        public int? Friends_count;

        [JsonProperty("listed_count")]
        public int? Listed_count;

        [JsonProperty("favourites_count")]
        public int? FavouritesCount;

        [JsonProperty("statuses_count")]
        public int? StatusesCount;

        [JsonProperty("created_at")]
        public string CreatedAt;

        [JsonProperty("profile_banner_url")]
        public string ProfileBannerUrl;

        [JsonProperty("profile_image_url_https")]
        public string ProfileImageUrlHttps;

        [JsonProperty("default_profile")]
        public bool DefaultProfile;

        [JsonProperty("default_profile_image")]
        public bool DefaultProfileImage;

        [JsonProperty("withheld_in_countries")]
        public string[] WithheldInCountries;

        [JsonProperty("withheld_scope")]
        public string WithheldScope;

        public TwitterUser()
        {
        }
    }
}
