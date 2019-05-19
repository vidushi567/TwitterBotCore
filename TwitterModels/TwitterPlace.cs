using System;
using Newtonsoft.Json;

namespace TwitterBotCore.TwitterModels
{
    public class TwitterPlace
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("place_type")]
        public string PlaceType;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("full_name")]
        public string FullName;

        [JsonProperty("country_code")]
        public string CountryCode;

        [JsonProperty("country")]
        public string Country;

        [JsonProperty("bounding_box")]
        public BoundingBox BoundingBox;

        public TwitterPlace()
        {
        }
    }
}
