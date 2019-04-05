using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Models
{
    public class Face
    {
        [JsonProperty("faceAttributes")]
        public FaceAttributes FaceAttributes { get; set; }
    }

    public class FaceAttributes
    {
        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("emotion")]
        public Emotion Emotion { get; set; }
    }

    public partial class Emotion
    {
        [JsonProperty("anger")]
        public double Anger { get; set; }

        [JsonProperty("contempt")]
        public double Contempt { get; set; }

        [JsonProperty("disgust")]
        public double Disgust { get; set; }

        [JsonProperty("fear")]
        public double Fear { get; set; }

        [JsonProperty("happiness")]
        public double Happiness { get; set; }

        [JsonProperty("neutral")]
        public double Neutral { get; set; }

        [JsonProperty("sadness")]
        public double Sadness { get; set; }

        [JsonProperty("surprise")]
        public double Surprise { get; set; }
    }
    
}
