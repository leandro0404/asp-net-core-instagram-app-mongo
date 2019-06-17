using instagram.Models.Base;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace instagram.Models
{
    [BsonIgnoreExtraElements]
    public class Post : BaseModel
    {
        [JsonProperty("author")]
        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("place")]
        [JsonProperty("place")]
        public string Place { get; set; }

        [BsonElement("description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [BsonElement("hashtags")]
        [JsonProperty("hashtags")]
        public string HashTags { get; set; }

        [BsonElement("image")]
        [JsonProperty("image")]
        public string Image { get; set; }

        [BsonElement("likes")]
        [JsonProperty("likes")]
        public int Likes { get; set; }

        [BsonElement("createdAt")]
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
