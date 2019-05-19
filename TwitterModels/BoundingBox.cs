using System;
using Newtonsoft.Json;

namespace TwitterBotCore.TwitterModels
{
    public class Coordinates
    {
        [JsonProperty("coordinates")]
        public float[] Coordinate = new float[2];

        [JsonProperty("type")]
        public string Type;
    }
    public class BoundingBox
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("coordinates")]
        public float[][][] Coordinates;

        public BoundingBox()
        {
        }
    }
}
